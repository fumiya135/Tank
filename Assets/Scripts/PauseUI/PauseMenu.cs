using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] public GameObject pauseMenuUI;

    [SerializeField] public GameObject resumeButton;
    [SerializeField] public GameObject menuButton;
    [SerializeField] public GameObject quitButton;
    [SerializeField] public GameObject quitText;

    GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        player = GameObject.Find("Tank");
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<ThirdPersonControler>().enabled = true;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        player = GameObject.Find("Tank");
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<ThirdPersonControler>().enabled = false;
    }

    public void LoadMenu()
    {
        Debug.Log("loading");
    }

    public void QuitMenu()
    {
        resumeButton.SetActive(false);
        menuButton.SetActive(false);
        quitButton.SetActive(false);
        quitText.SetActive(true);
    }

    public void BackQuitMenu()
    {
        quitText.SetActive(false);
        resumeButton.SetActive(true);
        menuButton.SetActive(true);
        quitButton.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("quit");
    }
}
