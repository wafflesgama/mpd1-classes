using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign the UI Text object to display the timer

    public bool beginOnStart = true;

    private float startTime; // Time when the timer started
    private bool isRunning; // Flag to check if the timer is running

    void Awake()
    {
        isRunning = false; // Initialize timer as not running
    }


    private void Start()
    {

        if (beginOnStart)
            StartTimer();

    }
    void Update()
    {
        if (isRunning)
        {
            float elapsedTime = Time.time - startTime; // Calculate elapsed time
            UpdateTimerDisplay(elapsedTime);
        }
    }

    public void StartTimer()
    {
        if (!isRunning)
        {
            isRunning = true;
            startTime = Time.time; // Set start time when the timer starts
        }
    }

    public void PauseTimer()
    {
        if (isRunning)
        {
            isRunning = false;
        }
    }

    public void StopTimer()
    {
        isRunning = false;
        startTime = Time.time; // Reset start time to effectively stop and reset
        UpdateTimerDisplay(0f); // Update display to show 0 time
    }

    private void UpdateTimerDisplay(float elapsedTime)
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60); // Get whole minutes
        int seconds = Mathf.FloorToInt(elapsedTime % 60); // Get whole seconds

        // Format seconds with leading zero (00:0X)
        string formattedSeconds = seconds.ToString("00");

        timerText.text = minutes + ":" + formattedSeconds;
    }
}
