using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Image buttonImage;        // Reference to the button's Image component
    public Sprite newImage;          // The new image to change to on click
    public Sprite originalImage;     // The original image to revert to

    private bool isOriginalImage = true; // Tracks the current image state

    // Method to toggle the button's image
    public void ToggleButtonImage()
    {
        if (buttonImage != null)
        {
            if (isOriginalImage)
            {
                buttonImage.sprite = newImage;
            }
            else
            {
                buttonImage.sprite = originalImage;
            }

            // Toggle the flag
            isOriginalImage = !isOriginalImage;
        }
    }
}
