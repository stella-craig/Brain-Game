using UnityEngine;
using TMPro;

public class PracticeCrateFall : MonoBehaviour
{
    private float swayAmount;
    private float swaySpeed;
    private float fallSpeed;
    private float originalX;
    private float destroyYPosition = -2.8f;
    private int crateValue;
    private int initialCrateValue; // store the original value

    private TextMeshPro textComponent;

    // Initialize crate with its value and other properties
    public void Init(float swayAmount, float swaySpeed, float fallSpeed, int initialCrateValue)
    {
        this.swayAmount = swayAmount;
        this.swaySpeed = swaySpeed;
        this.fallSpeed = fallSpeed;
        this.crateValue = initialCrateValue; // Set the initial crate value
        this.initialCrateValue = initialCrateValue; // Store the initial value

        // Log to verify initial value
        //Debug.Log("Crate initialized with value: " + crateValue);

        originalX = transform.position.x;
        textComponent = GetComponentInChildren<TextMeshPro>();

        if (textComponent != null)
        {
            textComponent.text = crateValue.ToString(); // Display initial value
        }
    }


    void Update()
    {
        // Move the crate downward at a constant speed
        transform.position += new Vector3(0, -fallSpeed * Time.deltaTime, 0);

        // Sway effect
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        transform.position = new Vector3(originalX + sway, transform.position.y, transform.position.z);
        transform.rotation = Quaternion.Euler(0, 0, sway * 20f);

        // Destroy the crate if it falls below the screen
        if (transform.position.y <= destroyYPosition)
        {
            HandleCrateOutOfBounds();
        }
    }

    // Handle the crate value being affected by a bullet
    public void SubtractValue(int bulletValue)
    {
        //Debug.Log($"Crate initial value: {crateValue}, Bullet value: {bulletValue}"); // Log initial values

        crateValue -= bulletValue; // Subtract the bullet's value

        // Log the updated crate value after subtraction
        //Debug.Log($"Updated crate value after subtraction: {crateValue}");

        // Update text display
        if (textComponent != null)
        {
            textComponent.text = crateValue.ToString();
        }

        // Check for destruction conditions
        if (crateValue == 0)
        {
            //Debug.Log("Crate value is zero, awarding points and destroying crate.");
            AwardPoints();
            Destroy(gameObject);
        }
        else if (crateValue < 0)
        {
            //Debug.Log("Crate value is below zero, deducting points and destroying crate.");
            DeductPoints();
            Destroy(gameObject);
        }
        else
        {
            //Debug.Log("Crate value is still above zero, crate will continue falling.");
        }
    }


    // Handle crate falling below the screen
    private void HandleCrateOutOfBounds()
    {
        if (crateValue > 0)
        {
            DeductPoints();
        }

        Destroy(gameObject);
    }

    // Methods to manage scoring
    private void AwardPoints()
    {
        // Implement score addition logic here
        PracticeScore.Instance.AddPoints(initialCrateValue); // Award points equal to the crate's value
    }

    private void DeductPoints()
    {
        // Implement score deduction logic here
        PracticeScore.Instance.DeductPoints(Mathf.Abs(initialCrateValue)); // Deduct points based on crate value
    }
}
