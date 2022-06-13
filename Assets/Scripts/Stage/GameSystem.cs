using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    [SerializeField] public PlayerStatusScriptable player;
    [SerializeField] public CloneDataScriptableObject clone;
    [SerializeField] public WaveManager wave;
    [SerializeField] public GameObject StartText;
    [SerializeField] public GameObject EndText;
    [SerializeField] public GameObject resultUI;
    [SerializeField] public GameObject playerDeadUI;

    public bool waveStart = true;

    private void Start()
    {
        StartText.SetActive(true);
        StartCoroutine("StartWave");

        // リザルトやリスタート用
        clone.Set_level(player.Get_level());
        clone.Set_exp(player.Get_exp());
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
    }

    private void PrintOutResult()
    {
        resultUI.SetActive(true);

        int level = player.Get_level() - clone.Get_level();
        int exp = player.Get_exp() - clone.Get_exp();
        int customPoint = player.Get_customPoint() - clone.Get_customPoint();

        ResultUI result = resultUI.GetComponent<ResultUI>();
        result.Set_levelText(level);
        result.Set_expText(exp);
        result.Set_expText(customPoint);
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(5);
        waveStart = true;
    }

    public void PushQuitOnPlayerDead()
    {
        PlayerBuchStatus();
        SceneManager.LoadScene("SafeHouse");
    }

    public void PushRestartOnPlayerDead()
    {
        PlayerBuchStatus();
        SceneManager.LoadScene("Stage1-1");
    }

    private void PlayerBuchStatus()
    {
        player.Set_level(clone.Get_level());
        player.Set_exp(clone.Get_exp());
        player.Set_customPoint(clone.Get_customPoint());
    }
}
