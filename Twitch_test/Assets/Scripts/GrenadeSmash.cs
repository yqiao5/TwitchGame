using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrenadeSmash : MonoBehaviour
{
    public GameObject grenadeExplosionPrefab;
    private bool onFloor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"|| collision.gameObject.tag=="Floor" && !onFloor)
        {
            onFloor = true;
            GameObject explode = Instantiate(grenadeExplosionPrefab, transform.position,Quaternion.identity);
            //Debug.Log(transform.position);
            explode.name = "Explosion";
            explode.transform.SetParent(GameObject.Find("ExplosionHolder").transform);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Character>().DecreaseHealth(100);
        }
    }
}
