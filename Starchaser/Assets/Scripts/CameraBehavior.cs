using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBehavior : MonoBehaviour
{
    /*public GameObject target;
    public GameObject verticalRotation;
    private float rotationSpeed = 250;
    public float startingXDistance, startingZDistance, startingYDistance;*/
    public CinemachineFreeLook freelook;
    private float zoomSpeed = 25f;
    // Start is called before the first frame update
    void Awake()
    {      
        /*Camera.main.GetComponent<Transform>().localPosition = new Vector3(startingXDistance, startingYDistance, startingZDistance);
        this.transform.position = target.transform.position;*/
        freelook.m_CommonLens = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*this.transform.position = target.transform.position;

        float rotationIncrease = Input.GetAxis("Camera") * Time.deltaTime * rotationSpeed;
        float currentRotation = this.GetComponentInParent<Transform>().rotation.eulerAngles.y;
        
        float verticalRotationIncrease = Input.GetAxis("CameraVertical") * Time.deltaTime * rotationSpeed;
        float currentXRotation = verticalRotation.GetComponentInParent<Transform>().localRotation.eulerAngles.x;

        this.transform.rotation = Quaternion.Euler(new Vector3(0, currentRotation + rotationIncrease, 0));
        float xRotation = currentXRotation + verticalRotationIncrease;
        if (xRotation > 270)
            xRotation = Mathf.Clamp(xRotation, 315, 361);
        else if (xRotation < 90)
            xRotation = Mathf.Clamp(xRotation, -1, 45);
        verticalRotation.transform.localRotation = Quaternion.Euler(new Vector3(xRotation, 0, 0));*/

        float cameraZoom = Input.GetAxis("Mouse ScrollWheel");
        freelook.m_Lens.FieldOfView += cameraZoom * zoomSpeed;

        //Camera.main.GetComponent<Transform>().localPosition = Camera.main.GetComponent<Transform>().localPosition * (1 - cameraZoom);
    }
}
