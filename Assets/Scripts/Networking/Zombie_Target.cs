using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Zombie_Target : NetworkBehaviour {

	private UnityEngine.AI.NavMeshAgent agent;
	private Transform myTransform;
	public Transform targetTransform;
	private LayerMask raycastLayer;
	private float radius = 100;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		myTransform = transform;
		raycastLayer = 1<<LayerMask.NameToLayer("Player");

		if(isServer)
		{
			StartCoroutine(DoCheck());
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		//SearchForTarget();
		//MoveToTarget();
	}

	void SearchForTarget()
	{
		if(!isServer)
		{
			return;
		}

		if(targetTransform == null)
		{
			Collider[] hitColliders = Physics.OverlapSphere(myTransform.position, radius, raycastLayer);

			if(hitColliders.Length>0)
			{
				int randomint = Random.Range(0, hitColliders.Length);
				targetTransform = hitColliders[randomint].transform;
			}
		}

		if(targetTransform != null && targetTransform.GetComponent<BoxCollider>().enabled == false)
		{
			targetTransform = null;
		}
	}

	void MoveToTarget()
	{
		if(targetTransform != null && isServer)
		{
			SetNavDestination(targetTransform);
		}
	}

	void SetNavDestination(Transform dest)
	{
		agent.SetDestination(dest.position);
	}

	IEnumerator DoCheck()
	{
		for(;;)
		{
			SearchForTarget();
			MoveToTarget();
			yield return new WaitForSeconds(0.2f);
		}
	}

}
