using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateFromResources : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject grenadePrefab = Resources.Load("Prefabs/Grenade") as GameObject;
        GameObject grenade = GameObject.Instantiate(grenadePrefab, transform.position, Quaternion.Euler(90,0,0));
        grenade.transform.position = new Vector3(5, 0 , 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
