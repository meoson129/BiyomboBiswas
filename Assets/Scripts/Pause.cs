using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool isPaused = false;
    public Button restart;
    public Button quit;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Time.timeScale = 0f;
                isPaused = true;
                restart.gameObject.SetActive(true);
                quit.gameObject.SetActive(true);
                
            }
            else
            {
                Time.timeScale = 1f;
                isPaused = false;
                restart.gameObject.SetActive(false);
                quit.gameObject.SetActive(false);
               
            }
           
        }
    }

    public void RestartGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

   
}
