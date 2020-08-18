using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferScene : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (SceneManager.GetActiveScene().name == "Floor3")
        {
            SceneManager.LoadScene("Floor8");
        }
        else
        {
            Application.Quit();
        }
    }


    
}
