using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneStopwatch : MonoBehaviour
{
    public Text stopwatchText; // Reference to the UI text element to display the stopwatch time
    private Text resultsText;

    private float elapsedTime = 0f;
    private bool isTrackingTime = false;

    void Start()
    {
        // Start tracking time when the scene starts
        StartTrackingTime();

        // Subscribe to the scene unload event
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void Update()
    {
        // Update the elapsed time if tracking is enabled
        if (isTrackingTime)
        {
            elapsedTime += Time.deltaTime;
            UpdateStopwatchText();
        }
    }

    void UpdateStopwatchText()
    {
        // Calculate minutes, seconds, and milliseconds
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);

        // Format the time as minutes:seconds:milliseconds
        string formattedTime = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

        // Update the UI text to display the formatted time
        stopwatchText.text = formattedTime;
    }

    void OnSceneUnloaded(Scene scene)
    {
        // Stop tracking time when the scene is about to unload
        StopTrackingTime();
    }

    public void StartTrackingTime()
    {
        // Start tracking time
        isTrackingTime = true;
    }

    public void StopTrackingTime()
    {
        // Stop tracking time
        isTrackingTime = false;
    }

    public float GetElapsedTime()
    {
        // Return the total elapsed time
        return elapsedTime;
    }

    public string GetFinalTime()
    {
        // Calculate minutes, seconds, and milliseconds
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);

        // Format the final time as minutes:seconds:milliseconds
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    void OnDestroy()
    {
        // Unsubscribe from the scene unload event to avoid memory leaks
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }
}