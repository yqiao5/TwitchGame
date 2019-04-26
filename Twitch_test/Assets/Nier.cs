using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nier : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int direction = 0;
    public float fireCooldown;
    private float fireTimer;
    // Start is called before the first frame update
    void Start()
    {
        fireTimer = fireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer<=0)
        {
            fireTimer = fireCooldown;
            Fire();
        }
    }
    void Fire()
    {
        for (int i=0;i<6;i++)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, direction+i*60, 0));
        }
        direction+=10;
        if (direction > 359)
        {
            direction = 0;
        }
    }
}
