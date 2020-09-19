using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<Player>() != null)
            collision.collider.gameObject.GetComponent<Player>().TakeDamage(10);
    }
}
