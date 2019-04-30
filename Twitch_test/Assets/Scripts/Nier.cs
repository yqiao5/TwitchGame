using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nier : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;

        float x = Random.Range(0, speed);
        float z = Mathf.Sqrt(speed * speed - x * x);
        GetComponent<Rigidbody>().velocity=new Vector3(x,0,z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x>origin.x+10)
        {

        }
    }
}
