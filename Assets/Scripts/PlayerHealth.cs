using UnityEngine;
using System.Collections;

public class PlayerHealth : OnGameStart {

	public float health;
	float cooldown = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		cooldown += Time.deltaTime;
		if (health <= 0)
		{
			PhotonNetwork.Destroy(gameObject);
			SpawnPlayer();

		}

		if (transform.position.y < -20)
		{
			health = 0;
		}
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Bullet" && cooldown > 1)
		{
			cooldown = 0;
			health -= 34;
			transform.root.FindChild("injureSound").gameObject.SetActive(false);
			transform.root.FindChild("injureSound").gameObject.SetActive(true);
		}
	}
}
