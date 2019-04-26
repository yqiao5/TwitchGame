using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    Vector3 delta=new Vector3(0,30,-19);
    // Start is called before the first frame update
    void Start()
    {
        //delta = transform.position- player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position+delta;
    }
}
