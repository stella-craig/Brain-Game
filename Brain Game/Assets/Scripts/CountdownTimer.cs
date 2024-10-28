using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    private float timeRemaining;
    private bool timerRunning = false;
    public Text timerText; // Reference to the UI Text component for displaying the timer


    public void SetTime(float timeInSeconds)
    {
        timeRemaining = timeInSeconds;
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    void Update()
    {
        if (timerRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else if (timerRunning && timeRemaining <= 0)
        {
            timerRunning = false;
        }
    }

    public bool IsTimeUp()
    {
        return timeRemaining <= 0;
    }

    // Update the timer display in minutes:seconds format
    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }



    //public float startTimeInSeconds = 180f; // Default to 3 minutes (180 seconds)
    //private float remainingTime;
    //private bool timerRunning = false;
    //public Text timerText; // Reference to the UI Text component for displaying the timer

    //private bool isRunning = false;

    //void Start()
    //{
    //    ResetTimer(); // Initialize the timer with the starting time
    //}

    //void Update()
    //{
    //    if (isRunning)
    //    {
    //        if (remainingTime > 0)
    //        {
    //            remainingTime -= Time.deltaTime;
    //            UpdateTimerDisplay();
    //        }
    //        else
    //        {
    //            remainingTime = 0;
    //            isRunning = false;
    //            TimerEnded();
    //        }
    //    }
    //}

    //// Start the countdown timer
    //public void StartTimer(float customStartTime = -1)
    //{
    //    if (customStartTime > 0)
    //    {
    //        remainingTime = customStartTime;
    //    }
    //    else
    //    {
    //        remainingTime = startTimeInSeconds; // Default to 3 minutes
    //    }
    //    isRunning = true;
    //    UpdateTimerDisplay();
    //}

    //// Reset the timer to the default start time
    //public void ResetTimer()
    //{
    //    remainingTime = startTimeInSeconds;
    //    isRunning = false;
    //    UpdateTimerDisplay();
    //}

    //// Update the timer display in minutes:seconds format
    //private void UpdateTimerDisplay()
    //{
    //    int minutes = Mathf.FloorToInt(remainingTime / 60);
    //    int seconds = Mathf.FloorToInt(remainingTime % 60);
    //    timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    //}

    //// Handle timer reaching zero
    //private void TimerEnded()
    //{
    //    Debug.Log("Timer ended.");
    //    // Add additional logic here if needed when the timer reaches zero
    //}
}
