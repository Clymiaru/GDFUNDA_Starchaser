using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBehavior : MonoBehaviour
{
    [SerializeField] private ParticleSystem part;
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
    // Start is called before the first frame update
    void Awake()
    {

    }

    private void OnDestroy()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        Enemy target = other.GetComponent<Enemy>();

        if (target != null)
        {
            target.TakeDamage(10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Attack();
    }

    private void Attack()
    {
        part.Play();
    }

    private void Shoot()
    {

    }
}
