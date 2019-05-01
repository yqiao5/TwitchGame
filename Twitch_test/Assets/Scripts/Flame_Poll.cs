using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame_Poll : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.transform.position.x > transform.position.x)
            {
                transform.GetComponent<Collider>().isTrigger = false;
                transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("TwitchChat").GetComponent<TwitchChat>().StartBossPoll = true;
            }
        }
    }
}
