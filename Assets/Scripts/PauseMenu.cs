using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public CanvasGroup pauseMenuCanvasGroup;
    private int count = -1;
    public GameObject button;

    void Start()
    {
        SetPauseMenuVisible(false);
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            count++;
            if (count > 0)
            {
                Debug.Log("Resume plz");
            }
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        if (IsPauseMenuVisible())
        {
            Debug.Log("Start the game again");
            SetPauseMenuVisible(false);
            Time.timeScale = 1f;
        }
        else
        {
            SetPauseMenuVisible(true);
            Time.timeScale = 0f;
        }
        SetPauseMenuVisible(!IsPauseMenuVisible());
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }
    
    public bool isPaused()
    {
        return pauseMenuUI != null && !pauseMenuUI.activeSelf;
    }

    private void SetPauseMenuVisible(bool isVisible)
    {
        pauseMenuCanvasGroup.alpha = isVisible ? 1f : 0f;
        pauseMenuCanvasGroup.interactable = isVisible;
        pauseMenuCanvasGroup.blocksRaycasts = isVisible;
    }

    private bool IsPauseMenuVisible()
    {
        return pauseMenuCanvasGroup != null && pauseMenuCanvasGroup.alpha > 0f;
    }


}
