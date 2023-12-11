using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject firstCanvas;  // Reference to the first canvas
    public GameObject secondCanvas; // Reference to the second canvas

    private void Start()
    {
        // Ensure the first canvas is initially active, and the second canvas is inactive
        if (firstCanvas != null)
        {
            firstCanvas.SetActive(true);
        }

        if (secondCanvas != null)
        {
            secondCanvas.SetActive(false);
        }
    }

    public void SwitchCanvas()
    {
        // Toggle the visibility of the canvases when the button is pressed
        if (firstCanvas != null)
        {
            firstCanvas.SetActive(!firstCanvas.activeSelf);
        }

        if (secondCanvas != null)
        {
            secondCanvas.SetActive(!secondCanvas.activeSelf);
        }
    }
}
