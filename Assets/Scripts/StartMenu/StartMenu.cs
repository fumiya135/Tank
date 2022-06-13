using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] public PlayerStatusScriptable player;

    public void PushNewGame()
    {
        player.Set_firstPlayed(false);
        SceneManager.LoadScene("TutorialScene");
    }

    public void PushContinu()
    {
        if (player.Get_firstPlayed() == true)
        {
            SceneManager.LoadScene("SafeHouse");
        }
    }
}
