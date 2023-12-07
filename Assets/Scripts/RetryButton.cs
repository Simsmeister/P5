using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public Button yourButton; // Reference to your button in the Unity Editor

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        // Load the "NewScene" when the button is clicked
        SceneManager.LoadScene("Scenario#1");
    }
}
