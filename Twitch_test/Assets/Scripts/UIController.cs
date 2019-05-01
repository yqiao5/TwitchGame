using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Player Player;
    [SerializeField]
    private TwitchChat twitchChat;

    [SerializeField]
    private TextMeshProUGUI HealthText;
    [SerializeField]
    private TextMeshProUGUI Danmaku;
    public List<string> DanmakuText;
    private void Update()
    {
        setHealthText();
    }

    void setHealthText()
    {
        HealthText.text = "Health: " + Player.GetHealth() + "/100";
    }

    public void setDanmaku(string player)
    {
        Danmaku.text = "";
        string text = player + " fire a rocket.\n";
        if(DanmakuText.Count < 5)
        {
            DanmakuText.Add(text);
        }
        else
        {
            DanmakuText.RemoveAt(0);
            DanmakuText.Add(text);
        }
        for(int i = 0; i < DanmakuText.Count; i++)
        {
            Danmaku.text += DanmakuText[i];
        }
        Debug.Log(Danmaku.text.Split('\n').Length);
    }
}
