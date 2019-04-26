using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOnTouch : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool selfDestructAfterDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Character>().DecreaseHealth(damage);
            if (selfDestructAfterDamage)
            {
                Destroy(gameObject);
            }
        }
    }
}
