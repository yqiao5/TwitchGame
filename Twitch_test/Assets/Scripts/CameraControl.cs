using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform myCamera;
    public Transform target;
    public bool followX;
    public bool followY;
    public bool followZ;
    public Vector3 offset;
    public Vector3 defaultCameraRotation;
    public float defaultCameraDistance;
    public float zoomSpeed;
    public float rotateSpeed;

    private Vector3 cameraRotation;
    private float cameraDistance;
    void Start()
    {
        cameraRotation = defaultCameraRotation;
        cameraDistance = defaultCameraDistance;
    }
    // Update is called once per frame
    void Update()
    {
        Follow();
        Rotate();
        Zoom();
    }

    void Follow()
    {
        Vector3 temp = Vector3.zero;
        //Follow target position.x
        if (followX)
            temp.x = target.position.x + offset.x;
        else
            temp.x = offset.x;
        //Follow target position.y
        if (followY)
            temp.y = target.position.y + offset.y;
        else
            temp.y = offset.y;
        //Follow target position.z
        if (followZ)
            temp.z = target.position.z + offset.z;
        else
            temp.z = offset.z;

        transform.position = temp;
    }
    void Zoom()
    {
        
        Vector3 temp = Vector3.zero;
        temp.z = -cameraDistance;
        myCamera.localPosition = Vector3.Lerp(myCamera.localPosition, temp, zoomSpeed);
        
    }

    void Rotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(cameraRotation),rotateSpeed);
    }

}
