using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    // static accessible to other scripts
    public static bool gameIsPaused = false;
    public static uint step = 0;

    public List<GameObject> step_list;
    public GameObject pauseMenuUI;

    void Update()
    {
        for (int i = 0; i < 10; ++i)
        {
            if (i == step) step_list[i].SetActive(true);
            else step_list[i].SetActive(false);
        }

    }

    public void IncreaseStep()
    {
        if (step < 9) step++;
        else step = 0;
    }

    public void DecreaseStep()
    {
        if (step > 0) step--;
        else step = 9;
    } 

    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0.0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");
    }
}
