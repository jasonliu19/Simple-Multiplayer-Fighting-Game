using UnityEngine;
using System.Collections;

public class OnGameStart : MonoBehaviour {

	SpawnSpot[] spawns;
	// Use this for initialization
	void Start () {
		SpawnPlayer ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnPlayer()
	{
		spawns = FindObjectsOfType<SpawnSpot> ();
		Vector3 spawnposition = spawns [Random.Range(0, spawns.Length)].transform.position;
		GameObject myPlayer = PhotonNetwork.Instantiate("player", spawnposition, Quaternion.identity, 0);
		myPlayer.transform.FindChild ("playercamera").gameObject.SetActive (true);
		myPlayer.transform.FindChild ("arm").gameObject.SetActive (true);
		myPlayer.GetComponent<PlayerMovement>().enabled = true;
		myPlayer.GetComponent<PlayerHealth>().enabled = true;
	}
}
