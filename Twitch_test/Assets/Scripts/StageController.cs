using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public GameObject[] cannons;


    private float timer;
    private int groupID=0;
    public float fireCooldown;


    // Start is called before the first frame update
    void Start()
    {
        timer = fireCooldown;
        
    }

    void Fire(int ID)
    {
        cannons[2*ID].SetActive(true);
        cannons[2 * ID+1].SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<=0&&groupID<cannons.Length/2)
        {
            timer = fireCooldown;
            Fire(groupID);
            groupID++;
        }
    }
}
