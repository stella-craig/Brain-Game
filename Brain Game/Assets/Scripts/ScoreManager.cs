using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton instance
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
        GetComponent<CountdownTimer>().StartTimer();
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

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score); // Save current score

        // Check and save high score if this score is the highest
        int highScore = PlayerPrefs.GetInt("HighScore", 0); // Get current high score, default to 0
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        PlayerPrefs.Save(); // Ensure data is saved
    }
}
