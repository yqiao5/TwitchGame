using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grenade : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject grenadeExplosionPrefab;
    private bool onFloor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().DealDamage(damage);
        }
        Instantiate(grenadeExplosionPrefab,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
