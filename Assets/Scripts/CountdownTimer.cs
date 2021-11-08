using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{

    public float timeRemaining;
    public bool timerIsRunning = false;

    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
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
                Debug.Log("Time has run out");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

        if (!timerIsRunning)
        {
            if (timeRemaining <= 0)
            {
                SceneManager.LoadScene(3);
            }
        }
    }

    void DisplayTime (float timeToDisplay)
    {
        timeToDisplay++;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
