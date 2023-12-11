using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private SceneTransition sceneTransition;

    public Button yourButton; // Reference to your button in the Unity Editor
    public string sceneToLoad; // Name of the scene to load

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        sceneTransition = FindObjectOfType<SceneTransition>();

    }

    void TaskOnClick()
    {
        // Load the specified scene when the button is clicked
        SceneManager.LoadScene(sceneToLoad);
    }
    public void SwitchToScene(string sceneName)
    {
        sceneTransition.FadeToScene(sceneName);
    }
}
