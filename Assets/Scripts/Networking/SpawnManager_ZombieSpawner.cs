using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using HoloToolkit.Examples.SharingWithUNET;

public class SpawnManager_ZombieSpawner : NetworkBehaviour {

	[SerializeField] GameObject zombiePrefab;
	private GameObject zombieSpawn;
	private int counter;
	private int numberOfZombies = 1;
	private int maxNumberOfZombies = 80;
	private float waveRate = 5;
	private bool isSpawnActivated ;
    private Transform sharedWorldAnchorTransform;

    private Renderer rend;
  

     
    //OnStartServer
    public void Start ()
	{
        isSpawnActivated = true;
        transform.SetParent(SharedCollection.Instance.transform, false);
        zombieSpawn = this.gameObject.transform.parent.gameObject;//GameObject.FindGameObjectsWithTag("ZombieSpawn");

        sharedWorldAnchorTransform = SharedCollection.Instance.gameObject.transform;
        rend = GetComponent<Renderer>();
        rend.material.color = Color.red;
        StartCoroutine(ZombieSpawner());
	}

	IEnumerator ZombieSpawner()
	{
		for(;;)
		{
             rend.material.color = Color.green;

            yield return new WaitForSeconds(waveRate);
			GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
			if(zombies.Length < maxNumberOfZombies)
			{
				CommenceSpawn();
			}
		}
	}

	void CommenceSpawn()
	{
		if(isSpawnActivated)
		{
			for(int i = 0; i < numberOfZombies; i++)
            {
                //SpawnZombies(sharedWorldAnchorTransform.transform.position);
                CmdSpawnZombies();

            }
		}
	}
    [Command]
    void CmdSpawnZombies()
    {
        counter++;
       // GameObject go = GameObject.Instantiate(zombiePrefab, spawnPos, Quaternion.identity) as GameObject;
        GameObject go = (GameObject)Instantiate(zombiePrefab, sharedWorldAnchorTransform.InverseTransformPoint(this.transform.position), Quaternion.Euler(this.transform.forward));
        go.GetComponent<Zombie_ID>().zombieID = "Zombie " + counter;
        go.GetComponentInChildren<TextMesh>().text += "Zombie " + counter;
        NetworkServer.Spawn(go);
    }
    void SpawnZombies(Vector3 spawnPos)
	{
		counter++;
		GameObject go = GameObject.Instantiate(zombiePrefab, spawnPos, Quaternion.identity) as GameObject;
       // GameObject go = (GameObject)Instantiate(zombiePrefab, sharedWorldAnchorTransform.InverseTransformPoint(this.transform.position), Quaternion.Euler(this.transform.forward));
        go.GetComponent<Zombie_ID>().zombieID = "Zombie " + counter;
        go.GetComponentInChildren<TextMesh>().text+="Zombie " + counter;
        NetworkServer.Spawn(go);
	}

}
