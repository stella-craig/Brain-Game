using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public CrateSpawner crateSpawner;          // Reference to the CrateSpawner to control crate spawning
    public CountdownTimer countdownTimer;      // Reference to the CountdownTimer for level time limits
    public BarrelControl barrelControl;        // Reference to BarrelControl to reset ammo
    public ScoreManager scoreManager;

    public TextMeshProUGUI levelText;          // UI to display the current level
    public TextMeshProUGUI boxesRemainingText; // UI to display boxes left

    public Slider progressBar;

    private int currentLevel = 1;
    private int currentLevelIndex = 0;         // Current level index (starting from level 0)
    private int boxesRemaining = 0;
    private bool levelActive = false;          // Is the current level active?


    // Levels: specify the number of crates and time allowed (in seconds)
    private int[] levelCrates = { 5, 7, 10 };  // Number of crates for each level
    private float[] levelTimes = { 60f, 90f, 120f }; // Time allowed for each level in seconds

    void Start()
    {
        UpdateLevelText();
        StartLevel(currentLevelIndex);
    }

    // Start the specified level
    public void StartLevel(int levelIndex)
    {
        currentLevel = levelIndex + 1;
        UpdateLevelText();

        if (levelIndex < 0 || levelIndex >= levelCrates.Length)
        {
            Debug.LogError("Invalid level index");
            return;
        }

        currentLevelIndex = levelIndex;
        levelActive = true;

        // Reset ammo to 50 of each type
        barrelControl.ResetAmmo();

        // Update the level display
        if (levelText != null)
        {
            levelText.text = "Level " + (levelIndex + 1);
        }

        // Set the box counter for the level
        boxesRemaining = levelCrates[levelIndex];
        UpdateBoxesRemainingText();

        UpdateProgressBar();

        // Start spawning crates for the current level
        StartCoroutine(crateSpawner.SpawnCrates());

        // Set and start the countdown timer
        countdownTimer.SetTime(levelTimes[levelIndex]);
        countdownTimer.StartTimer();
    }

    void Update()
    {
        if (levelActive && countdownTimer.IsTimeUp())
        {
            LevelFailed();
        }
    }

    // Called when the level is completed successfully
    private void LevelCompleted()
    {
        levelActive = false;
        Debug.Log("Level " + (currentLevelIndex + 1) + " completed!");

        // Move up a level if there are more levels
        if (currentLevelIndex < levelCrates.Length - 1)
        {
            StartLevel(currentLevelIndex + 1);
        }
        else
        {
            ScoreManager.Instance.SaveScore();
            Debug.Log("Congratulations! You've completed all levels.");
            SceneManager.LoadScene("EndScreen");
            // Optionally, reset to the first level or display a "game completed" message
            // StartLevel(0);
        }
    }

    // Called when the player fails to complete the level within the time limit
    private void LevelFailed()
    {
        levelActive = false;
        Debug.Log("Level " + (currentLevelIndex + 1) + " failed!");

        // Move down a level if possible
        if (currentLevelIndex > 0)
        {
            StartLevel(currentLevelIndex - 1);
        }
        else
        {
            Debug.Log("Returning to the starting level.");
            StartLevel(0);
        }
    }

    private void UpdateBoxesRemainingText()
    {
        if (boxesRemainingText != null)
        {
            boxesRemainingText.text = "x" + boxesRemaining;
        }
    }

    public void DecreaseBoxCount(bool scoreIncreased)
    {
        if (scoreIncreased)
        {
            boxesRemaining--;
            UpdateBoxesRemainingText();
            UpdateProgressBar();

            if (boxesRemaining <= 0)
            {
                LevelCompleted();
            }
        }
    }

    private void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Level " + currentLevel;
        }
    }

    private void UpdateProgressBar()
    {
        if (progressBar != null)
        {
            float progress = 1f - ((float)boxesRemaining / levelCrates[currentLevelIndex]);
            progressBar.value = progress; // Update the slider based on progress
        }
    }
}
