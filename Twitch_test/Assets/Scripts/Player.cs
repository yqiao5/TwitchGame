using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private ParticleSystem bloodSplatter;
    [SerializeField] private Vector3 lastCheckPointPos;
    [SerializeField] private Transform JKCPlayer;
    [SerializeField] private GameObject JKCRagdoll;
    [SerializeField] private CameraControl JKCCameraConrtol;
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
        if (health <= 0)
            return;
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
        
        JKCPlayer.gameObject.SetActive(false);
        JKCRagdoll.transform.position = JKCPlayer.position;
        JKCRagdoll.transform.rotation = JKCPlayer.rotation;
        JKCRagdoll.SetActive(true);
        JKCCameraConrtol.SetDistance(10);
        IEnumerator coroutine = Reset(2f);
        StartCoroutine(coroutine);
    }




    private IEnumerator Reset(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        JKCRagdoll.SetActive(false);
        health = 100;
        JKCPlayer.position = lastCheckPointPos;
        JKCPlayer.gameObject.SetActive(true);
        JKCCameraConrtol.SetDistance(JKCCameraConrtol.defaultCameraDistance);
    }
}
