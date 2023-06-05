using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerSystem : MonoBehaviour
{
    public float timeRemaining = 300;
    public bool timerIsRunning = false;
    public Text timeText;
    public CofreScript cofreScript;
    private void Start()
    {
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                cofreScript.GetMoney();
                SceneManager.LoadScene(2);
                timerIsRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
