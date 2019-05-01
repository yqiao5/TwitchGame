using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;
using UnityEngine.UI;
using TMPro;


public class TwitchChat : MonoBehaviour
{
    public Transform player;

    private TcpClient twitchClient;
    private StreamReader reader;
    private StreamWriter writer;
    private int[] PollResult = new int[2];
    public bool StartPollRoom;
    private float intialPollTime;
    [SerializeField]
    private float UltimateCooldown;
    [SerializeField]
    private float PollTime;
    [SerializeField]
    private UIController uIController;
    [SerializeField]
    private GameObject leftRoad;
    [SerializeField]
    private GameObject rightRoad;
    [SerializeField]
    private TextMeshProUGUI roomChoice;
    // Start is called before the first frame update

    public string username, password, channelName; // Get the password from twitchapps.com

    public Text chatBox;

    void Start()
    {
        Connect();
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
        PollRoom();
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
                if (StartPollRoom)
                {
                    if (message[0] == '!')
                    {
                        if (message[1] == '1')
                        {
                            PollResult[0]++;
                            Debug.Log("1++");
                        }
                        if (message[1] == '2')
                        {
                            PollResult[1]++;
                            Debug.Log("2++");
                        }
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

    int[] PollRoom()
    {
        if (StartPollRoom)
        {
            roomChoice.gameObject.SetActive(true);
            roomChoice.text = "POLL! \n Big Spin:Thor's Hammer \n" + PollResult[0] + "     :     " + PollResult[1];
            if (PollTime>0)
            {
                PollTime -= Time.deltaTime;
            }
            else
            {
                StartPollRoom = false;
                PollTime = intialPollTime;
                Debug.Log(PollResult[0] + ":" + PollResult[1]);
                if(PollResult[0] > PollResult[1])
                {
                    leftRoad.SetActive(false);
                    roomChoice.gameObject.SetActive(false);
                }
                else
                {
                    rightRoad.SetActive(false);
                    roomChoice.gameObject.SetActive(false);
                }
                Array.Clear(PollResult, 0, PollResult.Length);
            }
        }
        return PollResult;
    }
}
