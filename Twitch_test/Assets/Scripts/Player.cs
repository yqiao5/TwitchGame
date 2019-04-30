using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private ParticleSystem bloodSplatter;
    private void Start()
    {

    }

    private void Update()
    {

    }

    public int GetHealth()
    {
        return health;
    }
    public void SetHealth(int h)
    {
        health = h;
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        bloodSplatter.Play();
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
}
