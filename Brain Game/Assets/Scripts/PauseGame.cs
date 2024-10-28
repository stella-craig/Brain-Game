using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Button pauseButton;     // Reference to the pause button
    public Text buttonText;        // Reference to the button's text component

    public static bool isPaused = false; // Tracks if the game is paused

    private void Start()
    {
        // Set the button text to "Pause" initially
        if (buttonText != null)
        {
            buttonText.text = "ll";
        }

        // Assign the PauseToggle method to the button's OnClick event
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(PauseToggle);
        }
    }

    public void PauseToggle()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGameFunction();
        }
    }

    private void PauseGameFunction()
    {
        Time.timeScale = 0; // Pauses the game
        isPaused = true;

        if (buttonText != null)
        {
            buttonText.text = "l>"; // Update button text
        }
    }

    private void ResumeGame()
    {
        Time.timeScale = 1; // Resumes the game
        isPaused = false;

        if (buttonText != null)
        {
            buttonText.text = "ll"; // Update button text
        }
    }
}
