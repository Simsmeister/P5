using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag "GameWin"
        if (other.CompareTag("GameWin"))
        {
            // Call the function to show the game over screen
            ShowGameOverScreen();
        }
    }

    private void ShowGameOverScreen()
    {
        // Assuming you have a scene named "GameWinScene" for the game over screen
        SceneManager.LoadScene("GameWinScene");

        // If you want to do something else, like displaying a UI panel instead of loading a new scene,
        // you can implement your game over logic here.
    }
}
