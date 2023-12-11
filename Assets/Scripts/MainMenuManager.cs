using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenuManager : MonoBehaviour
{
    private SceneTransition sceneTransition;
    void Start()
    {
        sceneTransition = FindObjectOfType<SceneTransition>();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwitchToScene(string sceneName)
    {
        sceneTransition.FadeToScene(sceneName);
    }
}
