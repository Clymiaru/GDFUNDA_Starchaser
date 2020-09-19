using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -100)
            player.transform.position = respawnPoint.transform.position;
    }
}
