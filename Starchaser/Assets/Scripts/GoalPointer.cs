using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPointer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject goal;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
        this.transform.LookAt(goal.transform, Vector3.up);
    }
}
