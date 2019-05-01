using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public float cameraDistance;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponentInParent<Player>().setCheckPointPos(new Vector3(transform.position.x,1,0));
            other.GetComponentInParent<Player>().JKCCameraConrtol.SetDistance(cameraDistance);
            Destroy(this.gameObject);
        }
    }
}
