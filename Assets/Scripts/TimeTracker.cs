using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    private float startTime;
    public TextMeshProUGUI currentTime;
    private PauseMenu pMenu;
    public Button restart;
    public Button quit;
    private float elapsedTime;
    public TMP_InputField usernameInput;
    private string timeString;
    // Start is called before the first frame update
    void Start()
    {
        if (restart != null)
        {
            restart.gameObject.SetActive(false);
        }
        if (quit != null)
        {
            quit.gameObject.SetActive(false);
        }
        
        
        startTime = Time.time;
        pMenu = FindObjectOfType<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(Time.timeScale > 0f))
        {
            return;
        }
        elapsedTime = Time.time - startTime;
        UpdateTimeUI(elapsedTime);
    }

    void UpdateTimeUI(float time)
    {
        int min = Mathf.FloorToInt(time / 60);
        int sec = Mathf.FloorToInt(time % 60);

        timeString = string.Format("{0:00}:{1:00}", min, sec);
        if (currentTime != null)
        {
            currentTime.text = "Time Elapsed: " + timeString;
        }
        
    }

    public void setTime(float newTime)
    {
        elapsedTime = newTime;
    }

    public float getTime()
    {
        return elapsedTime;
    }
}
