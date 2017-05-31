using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Zombie_Health : NetworkBehaviour {

	private int health = 50;

	public void DeductHealth (int dmg)
	{
		health -= dmg;
		CheckHealth();
	}

	void CheckHealth()
	{
		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
