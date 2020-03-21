using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using System.Net.Sockets;

public class CustomNetworkManagerHUD : MonoBehaviour
{
    NetworkManager networkManager;
    TelepathyTransport telepathyTransport;

    public InputField clientIPAddressInput;
    public InputField clientPortInput;

    public Text connectingToLabel;

    void Awake()
    {
        networkManager = GetComponent<NetworkManager>();
        telepathyTransport = GetComponent<TelepathyTransport>();
    }

    public void StartClient()
    {
        if(!NetworkClient.active)
        {
            // TODO: add ip
            try
            {
                //NetworkSetup(clientIPAddressInput.text, clientPortInput.text);
                NetworkManager.singleton.networkAddress = string.IsNullOrEmpty(clientIPAddressInput.text) ? "127.0.0.1" : clientIPAddressInput.text;
                telepathyTransport.port = (ushort)7777;
                networkManager.StartClient();
            } catch(SocketException socketEx)
            {
                Debug.Log($"Fuckin Sockets Ex: {socketEx.Message}");
            }
        }
    }

    // cancel connection attempts
    public void CancelConnection()
    {
        if(NetworkClient.isConnected)
        {
            networkManager.StopClient();
        }
    }

    // ip and port setup
    private void NetworkSetup(string ip, string strPort)
    {
        NetworkManager.singleton.networkAddress = string.IsNullOrEmpty(ip) ? "127.0.0.1" : ip;
        ushort port = 0;
        telepathyTransport.port = ushort.TryParse(strPort, out port) ? port : (ushort)7777;
        Debug.Log($"Connected on: {NetworkManager.singleton.networkAddress}::{telepathyTransport.port}");
    }
}
