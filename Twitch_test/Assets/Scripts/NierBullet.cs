using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NierBullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float lifeTime;
    [SerializeField] private float speed;
    
    private float lifeTimer;
    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeTime;
        GetComponent<Rigidbody>().velocity = transform.forward*speed;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer<=0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInParent<Player>().DealDamage(damage,false);
            Destroy(gameObject);
        }
    }

}
