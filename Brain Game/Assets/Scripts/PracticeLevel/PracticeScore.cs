using UnityEngine;
using TMPro;

public class PracticeScore : MonoBehaviour
{
    public static PracticeScore Instance; // Singleton instance
    private int score;

    [Header("UI")]
    public TextMeshProUGUI scoreText; // Reference to the UI text for displaying the score

    private void Awake()
    {
        // Set up the singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = 0;
        UpdateScoreUI();
    }

    // Method to add points
    public void AddPoints(int points)
    {
        //Debug.Log("Adding points: " + points);
        score += points;
        UpdateScoreUI();
    }

    // Method to deduct points
    public void DeductPoints(int points)
    {
        score -= points;
        UpdateScoreUI();
    }

    // Update the score text in the UI
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
            //Debug.Log("Score updated in UI: " + score);
        }
    }
}
