using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject finishButton;
    [SerializeField] TextController textController;
    bool IsTextPush = false;
    bool IsEventFinish = false;
    bool endState = false;
    //[SerializeField]
    //ClickController clickController;

    private void Start()
    {
        GameObject player = GameObject.Find("Tank");
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<ThirdPersonControler>().enabled = false;
    }

    void Update()
    {

        if (textController.finished)
        {
            textController.finished = false;
            //clickController.ViewClickIcon();
            return;
        }
        textController.TextUpdate(IsTextPush);
        textController.Eventfinished(IsEventFinish);
        IsTextPush = false;
        IsEventFinish = false;
    }
    public void PushText()
    {
        IsTextPush = true;
    }
    public void EventFinish()
    {
        IsEventFinish = true;
    }
    public void TutorialFinish()
    {
        textController.enabled = false;
        finishButton.SetActive(true);
    }

    public void EndPush()
    {
        //Debug.Log("load SafeHouse");
        SceneManager.LoadScene("SafeHouse");
    }
}
