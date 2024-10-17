using UnityEngine;
using SharpOSC;

public class OSCReceiver : MonoBehaviour
{
    private UDPListener listener;
    public int port = 9000; // Listening port

    void Start()
    {
        listener = new UDPListener(port);
        Debug.Log("OSC Receiver initialized on Port: " + port);

        // Start receiving OSC messages asynchronously
        StartListening();
    }

    // This method listens for incoming OSC messages
    private void StartListening()
    {
        // Run the listener on a new thread to avoid blocking the main Unity thread
        new System.Threading.Thread(() =>
        {
            while (true)
            {
                var packet = listener.Receive();
                if (packet != null)
                {
                    if (packet is OscMessage message)
                    {
                        // Extract the OSC message data and handle it
                        string address = message.Address;
                        string receivedValue = message.Arguments[0].ToString();
                        Debug.Log("OSC Message received. Address: " + address + ", Value: " + receivedValue);

                        // Process the received OSC message
                        ProcessOSCMessage(address, receivedValue);
                    }
                }
            }
        }).Start();
    }

    // Custom method to handle OSC messages
    private void ProcessOSCMessage(string address, string value)
    {
        // Example: If the message address is "/example", trigger an event in Unity
        if (address == "127.0.0.1")
        {
            Debug.Log("Processing OSC message with value: " + value);
            // Perform actions in Unity based on OSC message
        }
    }

    // Clean up the listener
    private void OnDestroy()
    {
        if (listener != null)
        {
            listener.Close();
            Debug.Log("OSC Listener closed.");
        }
    }
}
