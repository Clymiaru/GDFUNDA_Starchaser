using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 5;
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            speed /= 25;
        else if (Input.GetKeyUp(KeyCode.Space))
            speed *= 25;
        if (!chara.m_IsGrounded)
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");
            if (this.transform.rotation.eulerAngles.z > -10 && this.transform.rotation.eulerAngles.z < 10 ||
                this.transform.rotation.eulerAngles.z > 170 && this.transform.rotation.eulerAngles.z < 190)
            {
                this.gameObject.transform.Translate(rotationReference.transform.TransformDirection(Vector3.forward) *
                verticalMovement *
                Time.deltaTime * this.speed, Space.World);
            this.gameObject.transform.Translate(rotationReference.transform.TransformDirection(Vector3.right) *
                horizontalMovement *
                Time.deltaTime * this.speed, Space.World);
            }
            else if (this.transform.rotation.eulerAngles.z > 80 && this.transform.rotation.eulerAngles.z < 100)
            {
                if (this.transform.eulerAngles.y > -10 && this.transform.rotation.eulerAngles.y < 10)
                {
                    this.gameObject.transform.Translate(Vector3.up * verticalMovement *
                            Time.deltaTime * this.speed, Space.World);
                    this.gameObject.transform.Translate(Vector3.back * horizontalMovement *
                        Time.deltaTime * this.speed, Space.World);
                }
                else if (this.transform.eulerAngles.y > 260 && this.transform.rotation.eulerAngles.y < 280)
                {
                    this.gameObject.transform.Translate(Vector3.up * verticalMovement *
                            Time.deltaTime * this.speed, Space.World);
                    this.gameObject.transform.Translate(Vector3.right * horizontalMovement *
                        Time.deltaTime * this.speed, Space.World);
                }
                else if (this.transform.eulerAngles.y > 170 && this.transform.rotation.eulerAngles.y < 190)
                {
                    this.gameObject.transform.Translate(Vector3.up * verticalMovement *
                            Time.deltaTime * this.speed, Space.World);
                    this.gameObject.transform.Translate(Vector3.forward * horizontalMovement *
                        Time.deltaTime * this.speed, Space.World);
                }
                else if (this.transform.eulerAngles.y > 80 && this.transform.rotation.eulerAngles.y < 100)
                {
                    this.gameObject.transform.Translate(Vector3.up * verticalMovement *
                            Time.deltaTime * this.speed, Space.World);
                    this.gameObject.transform.Translate(Vector3.left * horizontalMovement *
                        Time.deltaTime * this.speed, Space.World);
                }
            }
            else if (this.transform.rotation.eulerAngles.z > 260 && this.transform.rotation.eulerAngles.z < 280)
            {
                if (this.transform.eulerAngles.y > -10 && this.transform.rotation.eulerAngles.y < 10)
                {
                    this.gameObject.transform.Translate(Vector3.up * verticalMovement *
                            Time.deltaTime * this.speed, Space.World);
                    this.gameObject.transform.Translate(Vector3.forward * horizontalMovement *
                        Time.deltaTime * this.speed, Space.World);
                }
                else if (this.transform.eulerAngles.y > 260 && this.transform.rotation.eulerAngles.y < 280)
                {
                    this.gameObject.transform.Translate(Vector3.up * verticalMovement *
                            Time.deltaTime * this.speed, Space.World);
                    this.gameObject.transform.Translate(Vector3.left * horizontalMovement *
                        Time.deltaTime * this.speed, Space.World);
                }
                else if (this.transform.eulerAngles.y > 170 && this.transform.rotation.eulerAngles.y < 190)
                {
                    this.gameObject.transform.Translate(Vector3.up * verticalMovement *
                            Time.deltaTime * this.speed, Space.World);
                    this.gameObject.transform.Translate(Vector3.back * horizontalMovement *
                        Time.deltaTime * this.speed, Space.World);
                }
                else if (this.transform.eulerAngles.y > 80 && this.transform.rotation.eulerAngles.y < 100)
                {
                    this.gameObject.transform.Translate(Vector3.up * verticalMovement *
                            Time.deltaTime * this.speed, Space.World);
                    this.gameObject.transform.Translate(Vector3.right * horizontalMovement *
                        Time.deltaTime * this.speed, Space.World);
                }
            }
        }
    }
}
