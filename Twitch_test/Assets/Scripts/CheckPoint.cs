using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().setCheckPointPos(new Vector3(transform.position.x,1,0));
            Destroy(this.gameObject);
        }
    }
}
