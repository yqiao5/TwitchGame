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
            other.gameObject.GetComponentInParent<Player>().DealDamage(damage,false);
            if (selfDestructAfterDamage)
            {
                Destroy(gameObject);
            }
        }
    }

}
