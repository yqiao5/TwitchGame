using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        selfDestroy();
    }
    
    void selfDestroy()
    {
        Debug.Log(GetComponent<ParticleSystem>().IsAlive());
        if (!GetComponent<ParticleSystem>().IsAlive())
        {
            Destroy(this.gameObject);
        }
    }
}
