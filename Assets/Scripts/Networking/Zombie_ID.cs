using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using HoloToolkit.Examples.SharingWithUNET;

public class Zombie_ID : NetworkBehaviour {

	[SyncVar]
    public string zombieID;
	private Transform myTransform;
    private ZNetBehabior zb;

    // Use this for initialization
    void Start () 
	{
        zb = GetComponent<ZNetBehabior>();
        myTransform = transform;
      
    }

    // Update is called once per frame
    void Update () 
	{
        SetIdentity();
    }

	void SetIdentity()
	{
		if(myTransform.name == "" || myTransform.name == "Zombie(Clone)")
		{
			myTransform.name = zombieID;
            zb.AddTOtextMesh(zombieID);

        }
	}
}
