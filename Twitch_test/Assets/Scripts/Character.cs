using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private int Health;

    private bool dead;

    private void Start()
    {
        Health = 100;
    }

    private void Update()
    {
        die();
    }

    public int getHealth()
    {
        return Health;
    }
    public void setHealth(int Health)
    {
        Health = this.Health;
    }

    public void decreaseHealth(int damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            dead = true;
        }
    }

    void die()
    {
        if (dead)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}
