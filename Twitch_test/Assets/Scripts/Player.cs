﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private ParticleSystem bloodSplatter;
    [SerializeField] private Vector3 lastCheckPointPos;
    [SerializeField] private Transform JKCPlayer;
    [SerializeField] private GameObject JKCRagdoll;
    private IEnumerator coroutine;

    FMOD.Studio.EventInstance BGM;

    private void Start()
    {
        BGM = FMODUnity.RuntimeManager.CreateInstance("event:/BGM");
        BGM.start();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BossGate")
        {
            Debug.Log("BossGate");
            BGM.setParameterByName("Conditon", 0.5f);
        }
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
        FMODUnity.RuntimeManager.PlayOneShot("event:/GetHurt");
        if (health <= 0)
        {
            Die();
        }
    }

    //set last check point pos;
    public void setCheckPointPos(Vector3 cpPosition)
    {
        lastCheckPointPos = cpPosition;
    }

    public void Die()
    {
        health = 100;  
        JKCPlayer.position = lastCheckPointPos;
        
    }



    private IEnumerator DieCountDown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        JKCPlayer.position = lastCheckPointPos;
        JKCPlayer.rotation = Quaternion.Euler(0, 0, 0);
    }
}
