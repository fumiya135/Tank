using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] public GameObject pauseMenuUI;

    [SerializeField] public GameObject resumeButton;
    [SerializeField] public GameObject menuButton;
    [SerializeField] public GameObject audioUI;
    [SerializeField] public GameObject quitButton;
    [SerializeField] public GameObject quitText;


    [Header("audio alider")]
    [SerializeField] public Slider seSlider;
    [SerializeField] public Slider bgmSlider;

    [Header("audio data")]
    [SerializeField] public AudioValueScriptableObject data;

    GameObject player;
    GameObject gameSystem;

    private void Start()
    {
        seSlider.value = data.Get_seValue();
        bgmSlider.value = data.Get_bgmValue();
    }
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
        Set_audioValue();
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

    public void AudioMene()
    {
        resumeButton.SetActive(false);
        menuButton.SetActive(false);
        quitButton.SetActive(false);
        audioUI.SetActive(true);
    }

    public void QuitAudioMene()
    {
        resumeButton.SetActive(true);
        menuButton.SetActive(true);
        quitButton.SetActive(true);
        audioUI.SetActive(false);
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
        SceneManager.LoadScene("MainMenu");
    }

    public void Set_audioValue()
    {
        data.Set_seValue(seSlider.value);
        data.Set_bgmValue(bgmSlider.value);
    }
}
