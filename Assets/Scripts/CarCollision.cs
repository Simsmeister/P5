using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag "GameOver"
        if (other.CompareTag("GameOver"))
        {
            // Call the function to show the game over screen
            ShowGameOverScreen();
        }
    }

    private void ShowGameOverScreen()
    {
        // Assuming you have a scene named "GameOverScene" for the game over screen
        SceneManager.LoadScene("GameOverScene");

        // If you want to do something else, like displaying a UI panel instead of loading a new scene,
        // you can implement your game over logic here.
    }
}
