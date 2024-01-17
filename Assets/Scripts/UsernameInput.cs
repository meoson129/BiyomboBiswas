using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class UsernameInput : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_Text instruction;
    List<string> names = new List<string>();
    List<float> times = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (usernameInput.text.Length == 3)
            {
                float tempTime = PlayerPrefs.GetFloat("Time");
                times.Add(PlayerPrefs.GetFloat("Time1"));
                times.Add(PlayerPrefs.GetFloat("Time2"));
                times.Add(PlayerPrefs.GetFloat("Time3"));

                names.Add(PlayerPrefs.GetString("Name1"));
                names.Add(PlayerPrefs.GetString("Name2"));
                names.Add(PlayerPrefs.GetString("Name3"));

                for (int i = 0; i < 3; i++)
                {
                    if (times[i] <= 0)
                    {
                        times[i] = 1000f;
                    }

                    if (tempTime < times[i])
                    {
                        times.Insert(i, tempTime);
                        names.Insert(i, usernameInput.text);
                        break;
                    }
                }

                PlayerPrefs.SetFloat("Time1", times[0]);
                PlayerPrefs.SetFloat("Time2", times[1]);
                PlayerPrefs.SetFloat("Time3", times[2]);

                PlayerPrefs.SetString("Name1", names[0]);
                PlayerPrefs.SetString("Name2", names[1]);
                PlayerPrefs.SetString("Name3", names[2]);

                SceneManager.LoadScene("LeaderBoard");
            }
            else
            {
                instruction.text = "Please Ensure 3 Character Entry";
            }
            

        }


    }
}
