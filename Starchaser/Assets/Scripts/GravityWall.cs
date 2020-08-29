using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GravityWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<RigidbodyFirstPersonController>() != null)
        {
            Physics.gravity = transform.TransformDirection(Vector3.down * 9.8f);
            if (this.transform.rotation.eulerAngles.x == 90)
            {
                collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(-collision.collider.GetComponent<Transform>().rotation.eulerAngles.y - 90,
                -90, 270);
            }
            else if (this.transform.rotation.eulerAngles.x == 270)
            {
                collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(-collision.collider.GetComponent<Transform>().rotation.eulerAngles.y - 90,
                -90, 90);
            }
            else if (this.transform.rotation.eulerAngles.z == 90)
            {
                collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(-collision.collider.GetComponent<Transform>().rotation.eulerAngles.y,
                0, this.transform.rotation.eulerAngles.z);
            }
            else if (this.transform.rotation.eulerAngles.z == 270)
            {
                collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(collision.collider.GetComponent<Transform>().rotation.eulerAngles.y,
                0, this.transform.rotation.eulerAngles.z);
            }
            //collision.collider.GetComponent<Transform>().rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x,
            //    collision.collider.GetComponent<Transform>().rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z);
        }
    }
}
