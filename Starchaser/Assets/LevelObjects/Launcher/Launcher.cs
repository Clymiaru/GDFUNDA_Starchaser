using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private GameObject armPivot;

    //private void OnDrawGizmos()
    //{
    //    DrawRangeOfInteraction();
    //    DrawPathForTravel();
    //}

    //private void DrawPathForTravel()
    //{
    //    Gizmos.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
    //    Vector3 destination = transform.position - armPivot.transform.right * 10.0f;
    //    Gizmos.DrawLine(transform.position, destination);
    //}

    //private void DrawRangeOfInteraction()
    //{
    //    Gizmos.color = new Color(1.0f, 0.5f, 0.0f, 1.0f);
    //    Gizmos.DrawWireSphere(transform.position, GetComponent<SphereCollider>().radius);
    //}
}
