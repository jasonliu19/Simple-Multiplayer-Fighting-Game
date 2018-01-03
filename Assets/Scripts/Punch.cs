using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {
	
	// Use this for initialization
	
	float deathTimer = 0;
	
	void Start () {
		if (transform.rotation.eulerAngles.z != 0)
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-30, 0);
		else
			GetComponent<Rigidbody2D>().velocity = new Vector2 (30, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		deathTimer += Time.deltaTime;
		if (deathTimer > 0.2f)
			PhotonNetwork.Destroy (gameObject);
	}	
	
}
