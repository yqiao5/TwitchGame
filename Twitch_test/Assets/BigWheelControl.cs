using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWheelControl : MonoBehaviour
{
    float rotationSpeed= 360f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 50, 0);
    }
}
