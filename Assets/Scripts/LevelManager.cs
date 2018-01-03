using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour{

	// Update is called once per frame
	public void Quit () {
		Debug.Log ("we quit");
		Application.Quit ();
	}

	public void ChangeLevel(bool levelchange)
	{
		PhotonNetwork.Instantiate ("SwitchLevel", Vector3.zero, Quaternion.identity, 0);
		Debug.Log ("change level");
	}
}
