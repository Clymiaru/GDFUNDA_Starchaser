using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject target;
    public float startingXDistance, startingZDistance, startingYDistance;
    // Start is called before the first frame update
    void Awake()
    {      
        Camera.main.GetComponent<Transform>().localPosition = new Vector3(startingXDistance, startingYDistance, startingZDistance);
        this.transform.position = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.transform.position;

        float rotationIncrease = Input.GetAxis("Camera");
        float currentRotation = this.GetComponentInParent<Transform>().rotation.eulerAngles.y;

        this.transform.rotation = Quaternion.Euler(new Vector3(0, currentRotation + rotationIncrease, 0));

        float cameraZoom = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.GetComponent<Transform>().localPosition = Camera.main.GetComponent<Transform>().localPosition * (1 - cameraZoom);
    }
}
