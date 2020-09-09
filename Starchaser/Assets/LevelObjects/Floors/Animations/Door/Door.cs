using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private GameObject openVFXParent;
    [SerializeField] private GameObject closeVFXParent;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Open();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Close();
        }
    }

    void Open()
    {
        doorAnimator.SetTrigger("Open");
        openVFXParent.SetActive(true);
    }

    void Close()
    {
        doorAnimator.SetTrigger("Close");
        closeVFXParent.SetActive(true);
    }
}
