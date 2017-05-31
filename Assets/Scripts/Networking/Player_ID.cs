using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[NetworkSettings(sendInterval = 0.033f)]
public class Player_ID : NetworkBehaviour {

    [SyncVar]
    string playerUniqIdentity="lolplayer";
    private NetworkInstanceId _playerNetId;
    private Transform _myTransform;

    public override void OnStartLocalPlayer() {
        GetNetIdentity();
        SetPlayerIdentity();
    }


    // this is not going to run on the server. it is never called from server
    [Client]
    private void GetNetIdentity()
    {
        _playerNetId = GetComponent<NetworkIdentity>().netId;
        CmdTellServerMyIdentity(MakeUniqIdentity());
    }

    private string MakeUniqIdentity()
    {
        return "Player "+_playerNetId.ToString();
    }
    [Command]
    void CmdTellServerMyIdentity(string argPlayerIdentity)
    {
        playerUniqIdentity = argPlayerIdentity;
        //server will get the variable and syncit accross network
    }

    
    private void SetPlayerIdentity()
    {
        if (!isLocalPlayer)
        {
            _myTransform.name = playerUniqIdentity;
        }
        else
        {
            _myTransform.name = MakeUniqIdentity();

        }
    }


    // Use this for initialization
    void Awake () {
        _myTransform = this.transform;
	}
	

	// Update is called once per frame
	void Update () {
        //do set id here and not start or awake.. others may not be here yet
        if (_myTransform.name == "" || _myTransform.name == "Player(Clone)") {
            SetPlayerIdentity();
        }
	}
}
