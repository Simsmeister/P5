using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    private SceneTransition sceneTransition;
    public string nextSceneName;

    public GameObject fireflyInstance;
    void Start()
    {

        sceneTransition = FindObjectOfType<SceneTransition>();
        string currentSceneName = SceneManager.GetActiveScene().name;
        nextSceneName = GetNextSceneName(currentSceneName);
        fireflyInstance = GameObject.FindWithTag("FireflyChecker");

    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag "GameWin"
        if (other.CompareTag("GameWin"))
        {
            // Call the function to show the game over screen
            SwitchToScene(nextSceneName);
            Destroy(fireflyInstance);
        }
    }

    private void ShowGameOverScreen()
    {
        // Assuming you have a scene named "GameWinScene" for the game over screen
        SceneManager.LoadScene("GameWinScene");

        // If you want to do something else, like displaying a UI panel instead of loading a new scene,
        // you can implement your game over logic here.

    }
    public void SwitchToScene(string sceneName)
    {
        sceneTransition.FadeToScene(sceneName);
    }

    string GetNextSceneName(string currentSceneName)
    {
        switch (currentSceneName)
        {
            case "Scenario#1":
                return "Scenario#2";
            case "Scenario#2":
                return "Scenario#3";
            case "Scenario#3":
                return "OverallGameEnd"; // Loop back to the first scene
            default:
                Debug.LogError("Unknown scene name: " + currentSceneName);
                return currentSceneName;
        }
    }
}