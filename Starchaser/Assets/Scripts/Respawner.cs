using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;
    public float fallingThreshold = 10;
    private float currentFallTime = 0;
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -100)
            player.transform.position = respawnPoint.transform.position;
        if (!player.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().m_IsGrounded)
            currentFallTime += Time.deltaTime;
        else
            currentFallTime = 0;
        if (currentFallTime >= fallingThreshold)
        {
            player.transform.position = respawnPoint.transform.position;
            player.transform.rotation = Quaternion.Euler(Vector3.down);
            Physics.gravity = Vector3.down * 9.81f;
        }
    }
}
