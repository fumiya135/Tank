using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1 : MonoBehaviour
{
    [SerializeField] public GameObject tutorialManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tutorialManager.GetComponent<TutorialManager>().EventFinish();
            Destroy(this.gameObject);
        }
    }

    public void Set_Active(bool value)
    {
        this.gameObject.active = value;
    }
}
