using UnityEngine;
using TMPro;

public class EndScreenManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        // Retrieve the score and high score from PlayerPrefs
        int score = PlayerPrefs.GetInt("Score", 0); // Default to 0 if not found
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Display them on the UI
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }
}
