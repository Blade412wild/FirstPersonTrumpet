using SharpOSC;
using System;
using TMPro;
using UnityEngine;

public class OSCManager : MonoBehaviour
{
    [Header("UI Target Device UI")]
    public TMP_InputField TargerIPField;
    public TMP_InputField TargetPortField;

    [Header("UI Own Device UI")]
    public TMP_InputField OwnDeviceIPField;
    public TMP_InputField OwnDevicePortField;

    [Header("UI Data UI")]
    public TMP_InputField chatInput;
    public TMP_InputField chatIncomingData;

    private OSCSender sender;
    private OSCReceiver listener;

    private string incommingData;

    private void Update()
    {
        chatIncomingData.text = incommingData;
    }

    public void CreateUDPSender()
    {
        if (sender != null) return;
        string targetIP = TargerIPField.text;
        int targetPort = Convert.ToInt32(TargetPortField.text); 

        sender = new OSCSender(targetIP, targetPort);
    }

    public void CreateUDPListener()
    {
        if (listener != null) return;

        int ownPort = Convert.ToInt32(OwnDevicePortField.text);
            

        listener = new OSCReceiver(ownPort);

        // set event listener
        if(listener != null)
        {
            listener.OndataReceived += CheckIncomingMessage;
        }
    }

    public void SendMessage()
    {
        if (sender == null)
        {
            Debug.Log("create a Sender");
        }
        else
        {
            string value = chatInput.text;
            sender.SendMessage("button/test", value);
        }
    }

    private void CheckIncomingMessage(string value)
    {
        incommingData = value;
    }


    private void DestroyUDPSender()
    {
        sender.CloseSender();
        sender = null;

    }

    private void DestroyUDPListener()
    {
        listener.CloseListener();
        listener = null;
    }

    private void OnDestroy()
    {
        if (sender != null)
        {
            DestroyUDPSender();
        }

        if (listener != null)
        {
            DestroyUDPListener();
        }
    }
}
