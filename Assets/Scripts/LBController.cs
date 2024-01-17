using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LBController : MonoBehaviour
{
    public TMP_Text name1, name2, name3, score1, score2, score3;
    public Button mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        name1.text = PlayerPrefs.GetString("Name1");
        name2.text = PlayerPrefs.GetString("Name2");
        name3.text = PlayerPrefs.GetString("Name3");
        score1.text = PlayerPrefs.GetFloat("Time1").ToString();
        score2.text = PlayerPrefs.GetFloat("Time2").ToString();
        score3.text = PlayerPrefs.GetFloat("Time3").ToString();

        if (score1.text == "0" || score1.text == "1000")
        {
            score1.text = "";
        }
        if (score2.text == "0" || score2.text == "1000")
        {
            score2.text = "";
        }
        if (score3.text == "0" || score3.text == "1000")
        {
            score3.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
