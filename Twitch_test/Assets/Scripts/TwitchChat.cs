using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;
using UnityEngine.UI;


public class TwitchChat : MonoBehaviour
{
    public Transform player;

    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;
    private float LastUltimateTime;
    private int[] PollResult = new int[2];
    private bool StartPoll;
    private float intialPollTime;
    [SerializeField]
    private float UltimateCooldown;
    [SerializeField]
    private float PollTime;
    [SerializeField]
    private UIController uIController;
    // Start is called before the first frame update

    public string username, password, channelName; // Get the password from twitchapps.com

    public Text chatBox;

    void Start()
    {
        Connect();
        LastUltimateTime = Time.time;
        intialPollTime = PollTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!twitchClient.Connected)
        {
            Connect();
        }

        ReadChat();
        if (Input.GetKeyDown(KeyCode.J))
        {
            FireViewerWeapon("Grenade", "ok");
        }
        UltimateWeaponPoll();
        Poll();
    }

    private void Connect()
    {
        Debug.Log("connecting");
        twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        reader = new StreamReader(twitchClient.GetStream());
        writer = new StreamWriter(twitchClient.GetStream());
        writer.WriteLine("PASS " + password);
        writer.WriteLine("NICK " + username);
        writer.WriteLine("USER " + username + " 8 * :" + username);
        writer.WriteLine("JOIN #" + channelName);
        writer.Flush();
        if (twitchClient.Connected)
        {
            Debug.Log("connect successful");
        }
    }

    private void ReadChat()
    {
        if(twitchClient.Available > 0)
        {
            var message = reader.ReadLine();
            if (message.Contains("PRIVMSG"))
            {
                //get the users name
                var splitPoint = message.IndexOf("!", 1);
                var chatName = message.Substring(0, splitPoint);
                chatName = chatName.Substring(1);

                //get the users message
                splitPoint = message.IndexOf(":", 1);
                message = message.Substring(splitPoint + 1);
                print(String.Format("{0}: {1}", chatName, message));
                message = message.Replace("(", "").Replace(")", "").Replace(" ","");
                if (StartPoll)
                {
                    if (message[0] == '1')
                    {
                        PollResult[0]++;
                        Debug.Log("1++");
                    }
                    if (message[0] == '2')
                    {
                        PollResult[1]++;
                        Debug.Log("2++");
                    }
                }
                string[] str = message.Split(',');
                uIController.setDanmaku(chatName, str[0], str[1]);
            } 
        }
    }

    void FireViewerWeapon(string type,string viewerID)
    {
        switch (type)
        {
            case "Grenade":
                GameObject grenadePrefab = Resources.Load("Prefabs/Grenade") as GameObject;
                GameObject grenade = GameObject.Instantiate(grenadePrefab, new Vector3( player.position.x,10,player.position.z), Quaternion.Euler(90, 0, 0));                
                break;
        }
    }

    void UltimateWeaponPoll()
    {
        if(Time.time - LastUltimateTime > UltimateCooldown)
        {
            //StartPoll countdown
            StartPoll = true;
        }
    }

    int[] Poll()
    {
        if (StartPoll)
        {
            if (PollTime>0)
            {
                PollTime -= Time.deltaTime;
            }
            else
            {
                StartPoll = false;
                PollTime = intialPollTime;
                LastUltimateTime = Time.time;
                //Debug.Log(PollResult[0] + ":" + PollResult[1]);
                Array.Clear(PollResult, 0, PollResult.Length);
            }
        }
        return PollResult;
    }
}
