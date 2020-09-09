using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private float smooth = 0.0f;

    [SerializeField] private Transform target;

    [SerializeField] private float pitchMin = -40.0f;
    [SerializeField] private float pitchMax = 85.0f;

    private Transform cameraPos;
    private float mouseSensitivity = 10.0f;

    private float yaw;
    private float pitch;

    void Start()
    {
        //cameraPos = GameObject.Find("CamPos").transform;

        //transform.position = cameraPos.position;
        //transform.forward = cameraPos.forward;
    }

    void FixedUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        Vector3 targetRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = targetRotation;


        transform.position = target.position - target.forward;

        //transform.position = Vector3.Lerp(transform.position, cameraPos.position, Time.fixedDeltaTime * smooth);
        //transform.forward = Vector3.Lerp(transform.forward, cameraPos.forward, Time.fixedDeltaTime * smooth);
    }
}
