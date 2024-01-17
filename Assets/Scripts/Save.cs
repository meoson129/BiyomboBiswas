using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    public Button save;
    public Button loadButton;
    public Transform enemyPosition;
    public Transform playerPosition;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    TimeTracker timeTracker;
    PlayerMovement playerMovement;

    int isSaved = 0;
    // Start is called before the first frame update
    void Start()
    {
        isSaved = PlayerPrefs.GetInt("Save"); //1 if a saved file exists, 0 otherwise
        timeTracker = GetComponent<TimeTracker>();
        playerMovement = GetComponent<PlayerMovement>();

        save.gameObject.SetActive(false);
        loadButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
        {
            save.gameObject.SetActive(true);
            loadButton.gameObject.SetActive(true);
        }
        else
        {
            save.gameObject.SetActive(false);
            loadButton.gameObject.SetActive(false);
        }
    }

    public void SaveGame()
    {
        float savedTime = timeTracker.getTime();
        PlayerPrefs.SetFloat("SavedTime", savedTime);

        float Px = playerPosition.position.x;
        float Py = playerPosition.position.y;
        float Pz = playerPosition.position.z;
        PlayerPrefs.SetFloat("Px", Px);
        PlayerPrefs.SetFloat("Py", Py);
        PlayerPrefs.SetFloat("Pz", Pz);

        float Ex = enemyPosition.position.x;
        float Ey = enemyPosition.position.y;
        float Ez = enemyPosition.position.z;
        PlayerPrefs.SetFloat("Ex", Ex);
        PlayerPrefs.SetFloat("Ey", Ey);
        PlayerPrefs.SetFloat("Ez", Ez);

        if (key1 == null)
        {
            PlayerPrefs.SetString("K1", "null");
        }
        if (key2 == null)
        {
            PlayerPrefs.SetString("K2", "null");
        }
        if (key3 == null)
        {
            PlayerPrefs.SetString("K3", "null");
        }
        if (obstacle1 == null)
        {
            PlayerPrefs.SetString("O1", "null");
        }
        if (obstacle2 == null)
        {
            PlayerPrefs.SetString("O2", "null");
        }
        if (obstacle3 == null)
        {
            PlayerPrefs.SetString("O3", "null");
        }

        PlayerPrefs.SetInt("Save", 1); //Save File Exists


    }

    public void LoadGame()
    {
        if (isSaved == 1)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("SampleScene");
            float loadTime = PlayerPrefs.GetFloat("SavedTime");
            timeTracker.setTime(loadTime);

            float Px = PlayerPrefs.GetFloat("Px");
            float Py = PlayerPrefs.GetFloat("Py");
            float Pz = PlayerPrefs.GetFloat("Pz");
            playerPosition.position = new Vector3(Px, Py, Pz);

            int keyCount = 3;
            int obsCount = 3;

            if (PlayerPrefs.HasKey("K1"))
            {
                Destroy(key1);
                keyCount--;
            }
            if (PlayerPrefs.HasKey("K2"))
            {
                Destroy(key2);
                keyCount--;
            }
            if (PlayerPrefs.HasKey("K3"))
            {
                Destroy(key3);
                keyCount--;
            }
            if (PlayerPrefs.HasKey("O1"))
            {
                Destroy(obstacle1);
                obsCount--;
            }
            if (PlayerPrefs.HasKey("O2"))
            {
                Destroy(obstacle2);
                obsCount--;
            }
            if (PlayerPrefs.HasKey("O3"))
            {
                Destroy(obstacle3);
                obsCount--;
            }

            if (obsCount > keyCount)
            {
                playerMovement.AddKey();
            }
        }
        else
        {
            Debug.Log("No saved file");
        }


    }

}
