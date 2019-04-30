using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private ParticleSystem bloodSplatter;
    [SerializeField] private Vector3 lastCheckPointPos;

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
        if (health <= 0)
        {
            Die();
        }
    }

    //set last check point pos;
    public void setCheckPointPos(Vector3 cpPosition)
    {
        lastCheckPointPos = cpPosition;
        Debug.Log(lastCheckPointPos);
    }

    void Die()
    {
        transform.rotation = Quaternion.Euler(0, 0, -90);
        transform.position = lastCheckPointPos;
    }
}
