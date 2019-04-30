using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private ParticleSystem bloodSplatter;
    [SerializeField] private Vector3 lastCheckPointPos;

    private IEnumerator coroutine;

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

    public void Die()
    {
        health = 100;
        //transform.rotation = Quaternion.Euler(0, 0, -90);
        transform.position = lastCheckPointPos;
        coroutine = DieCountDown(2.0f);
        //StartCoroutine(coroutine);
    }



    private IEnumerator DieCountDown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = lastCheckPointPos;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
