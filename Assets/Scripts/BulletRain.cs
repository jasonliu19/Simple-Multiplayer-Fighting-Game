using UnityEngine;
using System.Collections;

public class BulletRain : MonoBehaviour {

	float cooldown = 0;
	BulletSpawn[] spawns;
	// Use this for initialization
	void Start () {
		spawns = FindObjectsOfType<BulletSpawn> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		cooldown += Time.deltaTime;
		if (cooldown > 0.5) {
			PhotonNetwork.Instantiate("Bulletprefab", spawns [Random.Range(0, spawns.Length)].transform.position, spawns [Random.Range(0, spawns.Length)].transform.rotation, 0);
			PhotonNetwork.Instantiate("gunshot", spawns [Random.Range(0, spawns.Length)].transform.position, spawns [Random.Range(0, spawns.Length)].transform.rotation, 0);
			cooldown = 0;
		}
	}
}
