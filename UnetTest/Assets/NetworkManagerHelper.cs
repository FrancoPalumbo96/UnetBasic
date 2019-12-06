using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class NetworkManagerHelper : MonoBehaviour
{
    public NetworkManager NetworkManager;
    public String gameName = "Game";
    public void HostGame()
    {
        NetworkManager.StartMatchMaker();
        NetworkManager.matchMaker.CreateMatch(gameName, NetworkManager.matchSize, true, "", "", "", 0, 0, new NetworkMatch.DataResponseDelegate<MatchInfo>(NetworkManager.OnMatchCreate));
    }

    public void ConnectToGame()
    {
        NetworkManager.StartMatchMaker();
        NetworkManager.matchMaker.ListMatches(0, 20, "", false, 0, 0, new NetworkMatch.DataResponseDelegate<List<MatchInfoSnapshot>>(NetworkManager.OnMatchList));

        StartCoroutine(FindMatches(2));
    }

    public void Disconnect()
    {
        NetworkManager.StopHost();
    }

    private IEnumerator FindMatches(float x)
    {
        yield return new WaitForSeconds(x);
        
        //Connects to the first match
        MatchInfoSnapshot match = NetworkManager.matches[0];
        if (match == null)
        {
            Debug.Log("Match Was not found");
            yield return null;
        }
        NetworkManager.matchName = match.name;
        NetworkManager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, new NetworkMatch.DataResponseDelegate<MatchInfo>(NetworkManager.OnMatchJoined));

    }
}
