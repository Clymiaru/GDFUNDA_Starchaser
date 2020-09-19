using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBehavior : MonoBehaviour
{
    [SerializeField] private float bouncePower;
    private void OnTriggerEnter(Collider other)
    {
        UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter player =
            other.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>();
        if (player != null)
        {
            if (!player.m_IsGrounded)
                player.GetComponent<Rigidbody>().AddForce(player.transform.TransformDirection(
                    new Vector3(0, bouncePower, player.transform.TransformDirection(Vector3.forward).z * 25)));
        }
    }
}
