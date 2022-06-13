using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatusPlane : MonoBehaviour
{
    [SerializeField] public ChangeStatusMene changeStatusMenu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            changeStatusMenu.showMenuState = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            changeStatusMenu.showMenuState = false;
        }
    }
}
