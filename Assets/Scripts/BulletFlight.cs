using UnityEngine;
using System.Collections;

public class BulletFlight : MonoBehaviour {

	// Use this for initialization

	float deathTimer = 0;

	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (15, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		deathTimer += Time.deltaTime;
		if (deathTimer > 4)
			PhotonNetwork.Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		PhotonNetwork.Destroy (gameObject);
	}
}
