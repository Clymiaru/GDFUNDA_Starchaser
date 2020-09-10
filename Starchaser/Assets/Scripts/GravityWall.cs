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
            if (collision.collider.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>() != null)
            {
                Physics.gravity = transform.TransformDirection(Vector3.down * 9.81f);
                if (this.transform.rotation.eulerAngles.z == 90)
                {
                    if (this.transform.rotation.eulerAngles.y == 180)
                    {
                        collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(collision.collider.GetComponent<Transform>().rotation.eulerAngles.y,
                        0, 270);
                    }
                    else if (this.transform.rotation.eulerAngles.y == 270)
                    {
                        collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(collision.collider.GetComponent<Transform>().rotation.eulerAngles.y - 90,
                            -90, 90);
                    }
                    else if (this.transform.rotation.eulerAngles.y == 90)
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
                else if (this.transform.rotation.eulerAngles.z == 180)
                {
                    collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(0, collision.collider.GetComponent<Transform>().rotation.eulerAngles.y,
                        180);
                }
                else if (this.transform.rotation.eulerAngles.y == 270)
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
