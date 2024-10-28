using UnityEngine;
using TMPro;

public class CrateFall : MonoBehaviour
{
    public LevelManager levelManager;

    private float swayAmount;
    private float swaySpeed;
    private float fallSpeed;
    private float originalX;
    private float destroyYPosition = -2.8f;
    private int crateValue;
    private int initialCrateValue; // store the original value

    
    private TextMeshPro textComponent;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        if (levelManager == null)
        {
            Debug.LogError("LevelManager not found in scene. Make sure it exists in the Hierarchy.");
        }
    }


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
        // Check if levelManager or textComponent is null
        if (levelManager == null) Debug.LogError("levelManager is null in CrateFall");
        if (textComponent == null) Debug.LogError("textComponent is null in CrateFall");

        crateValue -= bulletValue;

        if (textComponent != null)
        {
            textComponent.text = crateValue.ToString();
        }

        if (crateValue == 0)
        {
            AwardPoints();
            Destroy(gameObject);

            // Check for levelManager being null before calling DecreaseBoxCount
            if (levelManager != null)
            {
                levelManager.DecreaseBoxCount(true);
            }
            else
            {
                Debug.LogError("LevelManager reference is null when trying to decrease box count.");
            }
        }
        else if (crateValue < 0)
        {
            DeductPoints();
            Destroy(gameObject);
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
        ScoreManager.Instance.AddPoints(initialCrateValue); // Award points equal to the crate's value
    }

    private void DeductPoints()
    {
        // Implement score deduction logic here
        ScoreManager.Instance.DeductPoints(Mathf.Abs(initialCrateValue)); // Deduct points based on crate value
    }
}
