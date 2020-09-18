using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 1;
    private UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter chara;
    private GameObject rotationReference;

    void Awake()
    {
        this.rotationReference = GameObject.Find("CameraHolder");
        chara = GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>();
    }

    private void OnDestroy()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!chara.m_IsGrounded)
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            this.gameObject.transform.Translate(Vector3.forward *
                verticalMovement *
                Time.deltaTime * this.speed, Space.World);
            this.gameObject.transform.Translate(Vector3.right *
                horizontalMovement *
                Time.deltaTime * this.speed, Space.World);
        }
    }
}
