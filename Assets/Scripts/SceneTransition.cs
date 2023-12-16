using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeSpeed = 1.5f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }
    IEnumerator FadeIn() //changes to opacity of the image to full
    {
        float alpha = 1.0f;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            SetAlpha(alpha);
            yield return null;
        }
        //does so the menus cant be interacted with while fadings
        fadeCanvasGroup.interactable = false;
        fadeCanvasGroup.blocksRaycasts = false; 
    }
    IEnumerator FadeOut(string sceneName) //changes the opacity of the image to 0
    {
        fadeCanvasGroup.interactable = true;
        fadeCanvasGroup.blocksRaycasts = true;
        float alpha = 0.0f;
        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            SetAlpha(alpha);
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
    void SetAlpha(float alpha)
    {
        fadeCanvasGroup.alpha = alpha;
    }
}
