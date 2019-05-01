using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nier : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private TextMeshProUGUI remainTime;
    [SerializeField] private GameObject VictoryWall;
    private float CountDown = 30.0f;
    private Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        remainTime.text = "";
        float x = Random.Range(0, speed);
        float z = Mathf.Sqrt(speed * speed - x * x);
        GetComponent<Rigidbody>().velocity=new Vector3(x,0,z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x>origin.x+10)
        {

        }
        if(CountDown > 0)
        {
            CountDown -= Time.deltaTime;
        }
        else
        {
            transform.parent.gameObject.SetActive(false);
            remainTime.gameObject.SetActive(false);
            VictoryWall.GetComponent<Collider>().isTrigger = true;
        }
        remainTime.text = "Boss Time: " + (int)CountDown;
    }
}
