using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferScene : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Quit");

        Application.Quit();
    }


    
}
