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
    public Vector3 delta;
    public float distance;
    public float zoomSpeed;

    private float fraction = 0;
    // Update is called once per frame
    void Update()
    {
        Follow();
        Zoom();
    }

    void Follow()
    {
        Vector3 temp = Vector3.zero;
        //Follow target position.x
        if (followX)
            temp.x = target.position.x + delta.x;
        else
            temp.x = delta.x;
        //Follow target position.y
        if (followY)
            temp.y = target.position.y + delta.y;
        else
            temp.y = delta.y;
        //Follow target position.z
        if (followZ)
            temp.z = target.position.z + delta.z;
        else
            temp.z = delta.z;

        transform.position = temp;
    }
    void Zoom()
    {
        
        Vector3 temp = Vector3.zero;
        temp.z = -distance;
        myCamera.localPosition = Vector3.Lerp(myCamera.localPosition, temp, zoomSpeed);
        
    }

}
