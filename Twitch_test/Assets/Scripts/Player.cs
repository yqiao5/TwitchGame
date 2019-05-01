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
    public CameraControl JKCCameraConrtol;
    private IEnumerator coroutine;



    public int GetHealth()
    {
        return health;
    }
    public void SetHealth(int h)
    {
        health = h;
    }

    public void DealDamage(int damage,bool force)
    {
        if (health <= 0)
            return;
        health -= damage;
        bloodSplatter.Play();
        FMODUnity.RuntimeManager.PlayOneShot("event:/GetHurt");
        if (health <= 0)
        {
            Die(force);
        }
    }

    //set last check point pos;
    public void setCheckPointPos(Vector3 cpPosition)
    {
        lastCheckPointPos = cpPosition;
    }

    public void Die(bool force)
    {

        JKCPlayer.gameObject.SetActive(false);
        Vector3 temp= JKCPlayer.position;
        temp.y += 3 ;
        JKCRagdoll.transform.position = temp;
        JKCRagdoll.transform.rotation = JKCPlayer.rotation;
        JKCRagdoll.SetActive(true);
        JKCCameraConrtol.target = JKCRagdoll.transform;
        if (force) { JKCRagdoll.GetComponent<Rigidbody>().AddForce(Vector3.one * 5000f); }
        Debug.Log(JKCRagdoll.GetComponent<Rigidbody>().velocity);
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
        JKCCameraConrtol.target = JKCPlayer;
        JKCCameraConrtol.SetDistance(JKCCameraConrtol.defaultCameraDistance);
    }

}
