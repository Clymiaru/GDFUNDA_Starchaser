using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<Player>() != null)
        {
            collision.collider.gameObject.GetComponent<Player>().TakeDamage(10);

            Parameters param = new Parameters();
            param.PutExtra("PlayerHealth", (int)collision.collider.gameObject.GetComponent<Player>().Health);
            EventBroadcaster.Instance.PostEvent(EventNames.Starchaser.ON_PLAYER_HEALTH_UPDATE, param);
        }
    }
}
