using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThorHammer : MonoBehaviour
{
    //[SerializeField] private Transform tip;
    [SerializeField] private int damage;
    public float rotateSpeed;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        //speed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 temp = Vector3.zero;
        temp.z = rotateSpeed;
        transform.Rotate(temp * Time.deltaTime);
    }
    void Rotate()
    {
        Vector3 temp = Vector3.zero;
        temp.z = -30;
        transform.eulerAngles = temp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInParent<Player>().DealDamage(damage,true);
        }
    }
}
