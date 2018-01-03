using UnityEngine;
using System.Collections;

public class DestroySound : MonoBehaviour {

	// Use this for initialization
	float deathTimer = 0;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		deathTimer += Time.deltaTime;
		if (deathTimer > 3)
			PhotonNetwork.Destroy(gameObject);
	}
}
