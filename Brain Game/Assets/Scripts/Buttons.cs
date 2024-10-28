using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Image buttonImage;        // Reference to the button's Image component
    public Sprite newImage;          // The new image to change to on click
    public Sprite originalImage;     // The original image to revert to

    private bool isOriginalImage = true; // Tracks the current image state
    private bool isMuted = false;        // Tracks the current audio state

    // Method to toggle the button's image and mute/unmute audio
    public void ToggleButtonImage()
    {
        if (buttonImage != null)
        {
            // Toggle the button image
            buttonImage.sprite = isOriginalImage ? newImage : originalImage;
            isOriginalImage = !isOriginalImage;
        }

        // Toggle audio mute status
        ToggleAudio();
    }

    // Method to toggle all audio sources in the scene
    private void ToggleAudio()
    {
        isMuted = !isMuted; // Flip the mute state

        // Find all AudioSource components in the scene and mute/unmute them
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.mute = isMuted;
        }
    }
}
