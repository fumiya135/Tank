using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatusMene : MonoBehaviour
{
    [SerializeField] public GameObject changeStatus;
    [SerializeField] public GameObject changeStatusKeyDown;
    
    private GameObject player;

    public bool showMenuState;

    private void Start()
    {
        showMenuState = false;
    }

    private void Update()
    {
        if (showMenuState == true)
        {
            changeStatusKeyDown.SetActive(true);

            if (Input.GetKeyDown("c"))
            {
                changeStatusKeyDown.SetActive(true);
                changeStatus.SetActive(true);
                
                Time.timeScale = 0f;
                player = GameObject.Find("Tank");
                player.GetComponent<PlayerController>().enabled = false;
                player.GetComponent<ThirdPersonControler>().enabled = false;
            }
        }
        else
        {
            changeStatusKeyDown.SetActive(false);
        }
    }

    public void CloseChangeStatusMenu()
    {
        changeStatus.SetActive(false);

        Time.timeScale = 1f;
        player = GameObject.Find("Tank");
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<ThirdPersonControler>().enabled = true;
    }
}
