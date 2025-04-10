using Unity.VisualScripting;
using UnityEngine;

public class PouseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject OptionsMenuUI;

    private void Start()
    {
        PauseMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    public void Options()
    {
        OptionsMenuUI.SetActive(true);
       // PauseMenuUI.SetActive(false);

        Time.timeScale = 0f;
    }
}