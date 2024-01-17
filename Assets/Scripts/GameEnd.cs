using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameEnd : MonoBehaviour
{
    public GameObject player;
    bool m_playerExit;
    public GameObject time;
    TimeTracker timeTracker;
    

    void Start()
    {
        timeTracker = GetComponent<TimeTracker>();

    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_playerExit = true;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (m_playerExit) {
            EndLevel();
                }
    }

    void EndLevel()
    {

        Debug.Log("Done");
        float time = timeTracker.getTime();
        PlayerPrefs.SetFloat("Time", time);
        SceneManager.LoadScene("InputScene");
    }
}
