using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StormAudio : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI remainTime;
    [SerializeField] private GameObject VictoryWall;
    private float CountDown = 30.0f;
    FMOD.Studio.EventInstance StormB;
    // Start is called before the first frame update
    void Start()
    {
        remainTime.text = "";
        StormB = FMODUnity.RuntimeManager.CreateInstance("event:/StormB");
        StormB.start();
    }

    // Update is called once per frame
    void Update()
    {
        if (CountDown > 0)
        {
            CountDown -= Time.deltaTime;
        }
        else
        {
            transform.gameObject.SetActive(false);
            remainTime.gameObject.SetActive(false);
            VictoryWall.GetComponent<Collider>().isTrigger = true;
        }
        remainTime.text = "Boss Time: " + (int)CountDown;
    }
}
