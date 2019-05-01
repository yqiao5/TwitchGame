using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGate : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.transform.position.x > transform.position.x)
            {
                transform.GetComponent<Collider>().isTrigger = false;
            }
        }
    }
}
