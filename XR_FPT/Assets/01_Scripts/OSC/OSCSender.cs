using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharpOSC;

public class OSCSender : MonoBehaviour
{

    private UDPSender sender;
    public string ipAddress = "127.0.0.1";
    public int port = 9000;


    // Start is called before the first frame update
    void Start()
    {
        sender = new UDPSender(ipAddress, port);
        Debug.Log("OSC Sender Initialized on IP: " + ipAddress + "and port: " +  port);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendMessage("test/message", "hallo Nathan");
        }
    }

    private void SendMessage(string address, string messageContent)
    {
        var message = new OscMessage(address, messageContent);
        sender.Send(message);
        Debug.Log("OSC Message sent to " + address + ": " + messageContent);
    }

    private void OnDestroy()
    {
        if (sender != null)
        {
            sender.Close();
            Debug.Log("OSC Sender closed.");
        }
    }
}
