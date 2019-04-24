using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SetPosText : MonoBehaviour
{
    private Vector3 Pos;
    private void Start()
    {
        Pos = transform.parent.transform.position;
        GetComponent<TextMeshPro>().text = "(" + Pos.x/2 + ","+ Pos.z/2 + ")";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
