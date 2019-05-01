using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOnCollide : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool selfDestructAfterDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInParent<Player>().DealDamage(damage,false);
            if (selfDestructAfterDamage)
            {
                Destroy(gameObject);
            }
        }
    }
}
