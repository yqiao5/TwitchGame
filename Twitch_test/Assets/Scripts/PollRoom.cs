using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollRoom : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.transform.position.x > transform.position.x)
            {
                transform.GetComponent<Collider>().isTrigger = false;
                GameObject.Find("TwitchChat").GetComponent<TwitchChat>().StartPollRoom = true;
            }
        }
    }
}
