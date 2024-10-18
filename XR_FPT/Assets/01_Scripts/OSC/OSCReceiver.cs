using UnityEngine;
using SharpOSC;
using System.Threading; // For threading

public class OSCReceiver : MonoBehaviour
{
    private UDPListener listener;
    public int port = 9000; // Listening port
    private Thread listenerThread; // The background thread for listening
    private bool isListening = false; // Flag to control thread execution

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
        isListening = true; // Set the flag to true when starting

        // Run the listener on a new thread to avoid blocking the main Unity thread
        listenerThread = new Thread(() =>
        {
            while (isListening) // Continue while listening is true
            {
                var packet = listener.Receive();
                if (packet != null && packet is OscMessage message)
                {
                    // Extract the OSC message data and handle it
                    string address = message.Address;
                    string receivedValue = message.Arguments[0].ToString();
                    Debug.Log("OSC Message received. Address: " + address + ", Value: " + receivedValue);

                    // Process the received OSC message
                    ProcessOSCMessage(address, receivedValue);
                }
            }
        });

        listenerThread.Start(); // Start the thread
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
        // Stop listening and wait for the thread to finish
        if (listenerThread != null && listenerThread.IsAlive)
        {
            // Set the flag to false to stop the thread loop
            isListening = false;

            // Close the UDPListener to stop receiving new messages
            if (listener != null)
            {
                listener.Close();
                Debug.Log("OSC Listener closed.");
            }

            // Wait for the thread to exit
            listenerThread.Join();
            Debug.Log("OSC Listener thread has been stopped.");
        }
    }
}