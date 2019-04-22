using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;
using UnityEngine.UI;


public class Twitch_chat : MonoBehaviour
{
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
    }

    private void Connect()
    {
        twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        reader = new StreamReader(twitchClient.GetStream());
        writer = new StreamWriter(twitchClient.GetStream());

        writer.WriteLine("PASS " + password);
        writer.WriteLine("NICK " + username);
        writer.WriteLine("USER " + username + " 8 * :" + username);
        writer.WriteLine("JOIN #" + channelName);
        writer.Flush();



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
                GameObject grenadePrefab = Resources.Load("Prefabs/Grenade") as GameObject;
                GameObject grenade = GameObject.Instantiate(grenadePrefab, transform.position, Quaternion.Euler(90, 0, 0));
                grenade.transform.position = new Vector3(int.Parse(str[1]), 10, int.Parse(str[2]));
            } 


           


        }



    }

}
