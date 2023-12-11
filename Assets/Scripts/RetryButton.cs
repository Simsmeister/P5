using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public Button yourButton; // Reference to your button in the Unity Editor
    public string sceneToLoad; // Name of the scene to load

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        // Load the specified scene when the button is clicked
        SceneManager.LoadScene(sceneToLoad);
    }
}
