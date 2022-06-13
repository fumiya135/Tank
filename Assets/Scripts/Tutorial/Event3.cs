using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event3 : MonoBehaviour
{
    [SerializeField] public GameObject tutorialManger;
    [SerializeField] public List<GameObject> enemyList;

    private bool activeObject;

    private void Update()
    {
        activeObject = false;
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i].gameObject != null)
            {
                activeObject = true;
            }
        }

        if (activeObject == false)
        {
            tutorialManger.GetComponent<TutorialManager>().EventFinish();
        }
    }
}
