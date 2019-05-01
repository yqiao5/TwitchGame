using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grenade : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject grenadeExplosionPrefab;

    private float lifeTimer;
    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInParent<Player>().DealDamage(damage,false);
        }
        Instantiate(grenadeExplosionPrefab,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
