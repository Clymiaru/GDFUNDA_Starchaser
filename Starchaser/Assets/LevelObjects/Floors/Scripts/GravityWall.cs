using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GravityWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (Physics.gravity != transform.TransformDirection(Vector3.down * 9.81f))
        {
            UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter player = 
                collision.collider.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>();
            if (player != null)
            {
                if (!player.m_IsGrounded && !player.hasChangedOrientationRecently)
                {
                    Physics.gravity = transform.TransformDirection(Vector3.down * 9.81f);
                    StartCoroutine(ChangePlayerOrientation(player));
                    //I hate floating point comparisons
                    if (this.transform.rotation.eulerAngles.z > 80 && this.transform.rotation.eulerAngles.z < 100)
                    {
                        if (this.transform.rotation.eulerAngles.y > 170 && this.transform.rotation.eulerAngles.y < 190)
                        {
                            collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(collision.collider.GetComponent<Transform>().rotation.eulerAngles.y,
                            0, 270);
                        }
                        else if (this.transform.rotation.eulerAngles.y > 260 && this.transform.rotation.eulerAngles.y < 280)
                        {
                            collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(collision.collider.GetComponent<Transform>().rotation.eulerAngles.y - 90,
                                -90, 90);
                        }
                        else if (this.transform.rotation.eulerAngles.y > 80 && this.transform.rotation.eulerAngles.y < 100)
                        {
                            collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(-collision.collider.GetComponent<Transform>().rotation.eulerAngles.y + 90,
                                90, 90);
                        }
                        else
                        {
                            collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(-collision.collider.GetComponent<Transform>().rotation.eulerAngles.y,
                            0, 90);
                        }
                    }
                    else if (this.transform.rotation.eulerAngles.z > 170 && this.transform.rotation.eulerAngles.z < 190)
                    {
                        Debug.Log("upside down");
                        collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(0, collision.collider.GetComponent<Transform>().rotation.eulerAngles.y,
                            180);
                    }
                    else if (this.transform.rotation.eulerAngles.z > 260 && this.transform.rotation.eulerAngles.z < 280)
                    {
                        collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(0, collision.collider.GetComponent<Transform>().rotation.eulerAngles.x,
                            0);
                    }
                    else
                    {
                        collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(0, collision.collider.GetComponent<Transform>().rotation.eulerAngles.x,
                            0);
                    }
                    //collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x,
                    //    collision.collider.GetComponent<Transform>().rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z);
                }
            }
        }
    }

    private IEnumerator ChangePlayerOrientation(UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter player)
    {
        player.hasChangedOrientationRecently = true;
        yield return new WaitForSeconds(0.5f);
        player.hasChangedOrientationRecently = false;
    }
}
