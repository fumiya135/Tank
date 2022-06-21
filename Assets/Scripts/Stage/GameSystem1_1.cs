using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem1_1 : MonoBehaviour
{
    [SerializeField] public PlayerStatusScriptable player;
    [SerializeField] public CloneDataScriptableObject clone;
    [SerializeField] public WaveManager wave;
    [SerializeField] public GameObject StartText;
    [SerializeField] public GameObject EndText;
    [SerializeField] public GameObject resultUI;
    [SerializeField] public GameObject playerDeadUI;
    [SerializeField] public AudioSource bgm;
    [SerializeField] public AudioClip victorySE;

    public bool waveStart = true;

    private void Start()
    {
        StartText.SetActive(true);
        StartCoroutine("StartWave");

        // リザルトやリスタート用
        clone.Set_level(player.Get_level());
        clone.Set_expTotal(player.Get_expTotal());
        clone.Set_expNextLevel(player.Get_expNextLevel());
        clone.Set_customPoint(player.Get_customPoint());
    }

    private void Update()
    {
        if (waveStart == true)
        {
            StartText.SetActive(false);
            wave.WaveStart();
            waveStart = false;
        }

        if (wave.waveEnd == true)
        {
            EndText.SetActive(true);
        }
    }

    public void PlayerDead()
    {
        Time.timeScale = 0f;

        GameObject pauseUI = GameObject.Find("PauseUI");
        pauseUI.SetActive(false);

        GameObject UI = GameObject.Find("UI");
        UI.SetActive(false);

        playerDeadUI.SetActive(true);
    }

    // Press Result Button
    public void Result()
    {
        EndText.SetActive(false);
        Time.timeScale = 0f;

        GameObject player = GameObject.Find("Tank");
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<ThirdPersonControler>().enabled = false;

        GameObject pauseUI = GameObject.Find("PauseUI");
        pauseUI.SetActive(false);

        GameObject UI = GameObject.Find("UI");
        UI.SetActive(false);

        PrintOutResult();

        bgm.enabled = false;

        if (GameObject.Find("SE") != null)
        {
            SeManager se = GameObject.Find("SE").GetComponent<SeManager>();
            se.PlaySE(victorySE);
        }
    }

    private void PrintOutResult()
    {
        resultUI.SetActive(true);
        ResultUI result = resultUI.gameObject.GetComponent<ResultUI>();

        int level = player.Get_level() - clone.Get_level();
        int exp = player.Get_expTotal() - clone.Get_expTotal();
        int customPoint = player.Get_customPoint() - clone.Get_customPoint();

        result.Set_levelText(level);
        result.Set_expText(exp);
        result.Set_customPointText(customPoint);
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(5);
        waveStart = true;
    }

    public void PushQuitOnPlayerDead()
    {
        PlayerStatusReset();
        SceneManager.LoadScene("SafeHouse");
        PlayerEnable();
    }

    public void PushRestartOnPlayerDead()
    {
        PlayerStatusReset();
        SceneManager.LoadScene("Stage1-1");
        PlayerEnable();
    }

    public void PushQuit()
    {
        SceneManager.LoadScene("SafeHouse");
        PlayerEnable();
    }

    public void PushRestart()
    {
        SceneManager.LoadScene("Stage1-1");
        PlayerEnable();
    }

    private void PlayerStatusReset()
    {
        player.Set_level(clone.Get_level());
        player.Set_exp(clone.Get_exp());
        player.Set_expNextLevel(clone.Get_expNextLevel());
        player.Set_customPoint(clone.Get_customPoint());
    }

    private void PlayerEnable()
    {
        Time.timeScale = 1f;

        GameObject player = GameObject.Find("Tank");
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<ThirdPersonControler>().enabled = true;
    }
}
