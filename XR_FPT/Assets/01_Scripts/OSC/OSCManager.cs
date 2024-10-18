using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SharpOSC;

public class OSCManager : MonoBehaviour
{
    public OSCSender sender;
    private OSCReceiver listener;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void CreateUDPSender()
    {
        sender = new OSCSender("127.0.0.1", 9000);
    }

    public void CreateUDPListener()
    {
    }

    public void SendMessage()
    {
        sender.SendMessage("button/test", "hallo Nathan");
    }


    private void DestroyUDPSender()
    {
        sender.CloseSender();
        sender = null;
        
    }

    private void DestroyUDPListener()
    {

    }

    private void OnDestroy()
    {
        DestroyUDPSender();
        DestroyUDPListener();
    }



}
