using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private int Health;

    private void Start()
    {
        Health = 100;
    }

    private void Update()
    {

    }

    public int GetHealth()
    {
        return Health;
    }
    public void setHealth(int Health)
    {
        Health = this.Health;
    }

    public void DecreaseHealth(int damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
}
