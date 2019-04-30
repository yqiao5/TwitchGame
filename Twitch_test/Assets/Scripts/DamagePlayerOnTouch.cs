using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOnTouch : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool selfDestructAfterDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().DealDamage(damage);
            if (selfDestructAfterDamage)
            {
                Destroy(gameObject);
            }
        }
    }

}
