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
    // Start is called before the first frame update

    public string username, password, channelName; // Get the password from twitchapps.com

    public Text chatBox;

    void Start()
    {
        Connect();
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
                Debug.Log(message);
                string[] str = message.Split(',');
                Debug.Log(str[0]);
                Debug.Log(str[1]);
                //rocket (3,3)
                
                
                
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
}
