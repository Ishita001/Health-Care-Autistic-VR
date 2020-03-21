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

    public InputField hostIPAddressInput;
    public InputField hostPortInput;

    public Text connectingToLabel;

    void Awake()
    {
        networkManager = GetComponent<NetworkManager>();
        telepathyTransport = GetComponent<TelepathyTransport>();
    }

    public void StartHost()
    {
        Debug.Log($"IPFuck {string.IsNullOrEmpty(hostIPAddressInput.text)}");
        Debug.Log($"PortFuck {string.IsNullOrEmpty(hostPortInput.text)}");
        if (!NetworkClient.isConnected && !NetworkServer.active)
        {
            if (!NetworkClient.active)
            {
                Debug.Log("StartHost: starting server...");
                NetworkSetup(hostIPAddressInput.text, hostPortInput.text);
                networkManager.StartHost();
                Debug.Log("Transport shit -> "+Transport.activeTransport);
                Debug.Log("Network Address shit -> " + networkManager.networkAddress);
            }
        }
    }

    public void StopHost()
    {
        if(NetworkServer.active && NetworkClient.isConnected)
        {
            networkManager.StopHost();
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
