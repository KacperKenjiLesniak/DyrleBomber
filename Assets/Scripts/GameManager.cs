using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using UnityEngine;

public class GameManager : MonoBehaviourPun
{
    // Start is called before the first frame update
    
    [SerializeField]
    private GameObject playerPrefab;

    private Player[] playerList;

    private Vector3[] spawnPositions = new[] {new Vector3(-9.485f, 5.865f, 0), new Vector3(9.485f, -5.105f), };
    void Start()
    {
        playerList = PhotonNetwork.PlayerList;
        foreach (var player in playerList)
        {
            if (player.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
            {
                PhotonNetwork.Instantiate(this.playerPrefab.name, spawnPositions[player.GetPlayerNumber()],
                    Quaternion.identity, 0);
            }
        }
        // if (PlayerController.LocalPlayerInstance==null)
        // {
        //     Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
        //     // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
        // }else{
        //     Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
