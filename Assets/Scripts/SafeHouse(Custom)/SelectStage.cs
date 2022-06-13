using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStage : MonoBehaviour
{
    [SerializeField] public GameObject selectStage;
    [SerializeField] public GameObject selectStageKeyDown;
    private bool canSelect = false;
    private bool gkeydown = false;

    private bool selected = false;
    private int stargeNum = 0;

    private void Update()
    {
        if (canSelect == true && gkeydown == false)
        {
            selectStageKeyDown.SetActive(true);
            if (Input.GetKeyDown("g"))
            {
                selectStage.SetActive(true);
                selectStageKeyDown.SetActive(false);
                gkeydown = true;

                Time.timeScale = 0f;
                GameObject player = GameObject.Find("Tank");
                player.GetComponent<PlayerController>().enabled = false;
                player.GetComponent<ThirdPersonControler>().enabled = false;
            }
        }
        else
        {
            selectStageKeyDown.SetActive(false);
        }
    }

    public void CloseButton()
    {
        gkeydown = false;
        selectStage.SetActive(false);

        Time.timeScale = 1f;
        GameObject player = GameObject.Find("Tank");
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<ThirdPersonControler>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canSelect = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canSelect = false;
        }
    }

    public void SelectedStage(int value)
    {
        selected = true;
        stargeNum = value;
    }

    public void BuckSelecteStage()
    {
        selected = false;
    }

    public void DefineStage()
    {
        if (selected == true)
        {
            switch (stargeNum)
            {
                case 1:
                    SceneManager.LoadScene("Stage1-1");
                    Time.timeScale = 1f;
                    break;
                case 2:
                    SceneManager.LoadScene("Stage1-2");
                    Time.timeScale = 1f;
                    break;
                case 3:
                    SceneManager.LoadScene("Stage1-3");
                    Time.timeScale = 1f;
                    break;
                default:
                    break;
            }
        }
    }
}
