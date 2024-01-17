using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    public void ShowLeaderBoard()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
