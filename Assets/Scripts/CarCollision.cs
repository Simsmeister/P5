using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCollision : MonoBehaviour
{
    public string nextSceneName;

    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        nextSceneName = GetNextSceneName(currentSceneName);
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag "GameOver"
        if (other.CompareTag("GameOver") || other.CompareTag("NPCCar"))
        {
            // Call the function to show the game over screen
            ShowGameOverScreen(nextSceneName);
        }
    }

    private void ShowGameOverScreen(string sceneName)
    {
        // Assuming you have a scene named "GameOverScene" for the game over screen
        SceneManager.LoadScene(sceneName);

        // If you want to do something else, like displaying a UI panel instead of loading a new scene,
        // you can implement your game over logic here.
    }

    string GetNextSceneName(string currentSceneName)
    {
        switch (currentSceneName)
        {
            case "Scenario#1":
                return "GameOver1";
            case "Scenario#2":
                return "GameOver2";
            case "Scenario#3":
                return "GameOver3"; // Loop back to the first scene
            default:
                Debug.LogError("Unknown scene name: " + currentSceneName);
                return currentSceneName;
        }
    }
}
