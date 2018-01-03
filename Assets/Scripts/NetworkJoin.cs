using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NetworkJoin : MonoBehaviour {

	// Use this for initialization
	public bool offline;
	SpawnSpot[] spawns;
	public static int numberofplayers;

	void Start () 
	{
		PhotonNetwork.logLevel = PhotonLogLevel.Full;
		if (offline) 
		{
			PhotonNetwork.offlineMode = true;
		}
		else
		{
			PhotonNetwork.ConnectUsingSettings ("loool");
		}
	}
	
	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom(null);
		PlayButton button = FindObjectOfType<PlayButton> ();
		button.transform.GetComponent<Image>().enabled = true;
		button.transform.GetComponent<Button>().enabled = true;
		button.transform.FindChild ("Text").gameObject.SetActive (true);
	}

	void OnJoinedRoom()
	{
		GameObject lobbyPlayer = PhotonNetwork.Instantiate ("ConnectedPlayer", Vector3.zero, Quaternion.identity, 0);
		lobbyPlayer.GetComponent<LobbySynch>().enabled = true;
		if (PhotonNetwork.isMasterClient) 
		{
			numberofplayers++;
		}

	}



}
