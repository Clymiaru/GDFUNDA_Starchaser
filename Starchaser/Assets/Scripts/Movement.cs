using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 250;
    private UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter chara;
    private GameObject rotationReference;
    private Rigidbody rigidBody;

    void Awake()
    {
        this.rotationReference = Camera.main.gameObject;
        chara = GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>();
        rigidBody = GetComponent<Rigidbody>();
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
        if (!chara.m_IsGrounded && !chara.isBoosted)
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");
            if (this.transform.rotation.eulerAngles.z > -10 && this.transform.rotation.eulerAngles.z < 10 ||
                this.transform.rotation.eulerAngles.z > 170 && this.transform.rotation.eulerAngles.z < 190)
            {
                Vector3 zMove;
                Vector3 xMove;
                
                    zMove = Vector3.ProjectOnPlane(rotationReference.transform.TransformDirection(Vector3.right),
                    Vector3.up) * horizontalMovement * Time.deltaTime * this.speed;
               
               
                    xMove = Vector3.ProjectOnPlane(rotationReference.transform.TransformDirection(Vector3.forward),
                    Vector3.up) * verticalMovement * Time.deltaTime * this.speed;
                

                rigidBody.velocity = xMove + zMove + new Vector3(0, rigidBody.velocity.y, 0);
            }
            else if (this.transform.rotation.eulerAngles.z > 80 && this.transform.rotation.eulerAngles.z < 100)
            {
                if (this.transform.eulerAngles.y > -10 && this.transform.rotation.eulerAngles.y < 10)
                {
                    Vector3 hMove;
                    Vector3 vMove;
                    if (horizontalMovement != 0)
                        hMove = Vector3.back * horizontalMovement * Time.deltaTime * this.speed;
                    else
                        hMove = Vector3.forward * rigidBody.velocity.z;
                    if (verticalMovement != 0)
                        vMove = Vector3.up * verticalMovement * Time.deltaTime * this.speed;
                    else
                        vMove = Vector3.up * rigidBody.velocity.y;

                    rigidBody.velocity = vMove + hMove + new Vector3(rigidBody.velocity.x, 0, 0);
                }
                else if (this.transform.eulerAngles.y > 260 && this.transform.rotation.eulerAngles.y < 280)
                {
                    Vector3 hMove;
                    Vector3 vMove;
                    if (horizontalMovement != 0)
                        hMove = Vector3.right * horizontalMovement * Time.deltaTime * this.speed;
                    else
                        hMove = Vector3.right * rigidBody.velocity.x;
                    if (verticalMovement != 0)
                        vMove = Vector3.up * verticalMovement * Time.deltaTime * this.speed;
                    else
                        vMove = Vector3.up * rigidBody.velocity.y;

                    rigidBody.velocity = vMove + hMove + new Vector3(0, 0, rigidBody.velocity.z);
                }
                else if (this.transform.eulerAngles.y > 170 && this.transform.rotation.eulerAngles.y < 190)
                {
                    Vector3 hMove;
                    Vector3 vMove;
                    if (horizontalMovement != 0)
                        hMove = Vector3.forward * horizontalMovement * Time.deltaTime * this.speed;
                    else
                        hMove = Vector3.forward * rigidBody.velocity.z;
                    if (verticalMovement != 0)
                        vMove = Vector3.up * verticalMovement * Time.deltaTime * this.speed;
                    else
                        vMove = Vector3.up * rigidBody.velocity.y;

                    rigidBody.velocity = vMove + hMove + new Vector3(rigidBody.velocity.x, 0, 0);
                }
                else if (this.transform.eulerAngles.y > 80 && this.transform.rotation.eulerAngles.y < 100)
                {
                    Vector3 hMove;
                    Vector3 vMove;
                    if (horizontalMovement != 0)
                        hMove = Vector3.left * horizontalMovement * Time.deltaTime * this.speed;
                    else
                        hMove = Vector3.right * rigidBody.velocity.x;
                    if (verticalMovement != 0)
                        vMove = Vector3.up * verticalMovement * Time.deltaTime * this.speed;
                    else
                        vMove = Vector3.up * rigidBody.velocity.y;

                    rigidBody.velocity = vMove + hMove + new Vector3(0, 0, rigidBody.velocity.z);
                }
            }
            else if (this.transform.rotation.eulerAngles.z > 260 && this.transform.rotation.eulerAngles.z < 280)
            {
                if (this.transform.eulerAngles.y > -10 && this.transform.rotation.eulerAngles.y < 10)
                {
                    Vector3 hMove;
                    Vector3 vMove;
                    if (horizontalMovement != 0)
                        hMove = Vector3.forward * horizontalMovement * Time.deltaTime * this.speed;
                    else
                        hMove = Vector3.forward * rigidBody.velocity.z;
                    if (verticalMovement != 0)
                        vMove = Vector3.up * verticalMovement * Time.deltaTime * this.speed;
                    else
                        vMove = Vector3.up * rigidBody.velocity.y;

                    rigidBody.velocity = vMove + hMove + new Vector3(rigidBody.velocity.x, 0, 0);
                }
                else if (this.transform.eulerAngles.y > 260 && this.transform.rotation.eulerAngles.y < 280)
                {
                    Vector3 hMove;
                    Vector3 vMove;
                    if (horizontalMovement != 0)
                        hMove = Vector3.left * horizontalMovement * Time.deltaTime * this.speed;
                    else
                        hMove = Vector3.right * rigidBody.velocity.x;
                    if (verticalMovement != 0)
                        vMove = Vector3.up * verticalMovement * Time.deltaTime * this.speed;
                    else
                        vMove = Vector3.up * rigidBody.velocity.y;

                    rigidBody.velocity = vMove + hMove + new Vector3(0, 0, rigidBody.velocity.z);
                }
                else if (this.transform.eulerAngles.y > 170 && this.transform.rotation.eulerAngles.y < 190)
                {
                    Vector3 hMove;
                    Vector3 vMove;
                    if (horizontalMovement != 0)
                        hMove = Vector3.back * horizontalMovement * Time.deltaTime * this.speed;
                    else
                        hMove = Vector3.forward * rigidBody.velocity.z;
                    if (verticalMovement != 0)
                        vMove = Vector3.up * verticalMovement * Time.deltaTime * this.speed;
                    else
                        vMove = Vector3.up * rigidBody.velocity.y;

                    rigidBody.velocity = vMove + hMove + new Vector3(rigidBody.velocity.x, 0, 0);
                }
                else if (this.transform.eulerAngles.y > 80 && this.transform.rotation.eulerAngles.y < 100)
                {
                    Vector3 hMove;
                    Vector3 vMove;
                    if (horizontalMovement != 0)
                        hMove = Vector3.right * horizontalMovement * Time.deltaTime * this.speed;
                    else
                        hMove = Vector3.right * rigidBody.velocity.x;
                    if (verticalMovement != 0)
                        vMove = Vector3.up * verticalMovement * Time.deltaTime * this.speed;
                    else
                        vMove = Vector3.up * rigidBody.velocity.y;

                    rigidBody.velocity = vMove + hMove + new Vector3(0, 0, rigidBody.velocity.z);
                }
            }
        }
    }
}
