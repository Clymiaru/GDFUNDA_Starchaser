using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherBehavior : MonoBehaviour
{
    [SerializeField] private float forwardThrust;
    [SerializeField] private float upwardThrust;
    private void OnTriggerEnter(Collider other)
    {
        UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter player =
            other.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>();
        if (player != null)
        {
            player.isBoosted = true;
            player.gameObject.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.left) * forwardThrust +
                 transform.TransformDirection(Vector3.up) * upwardThrust);
        }
    }
}
