using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LobbySynch : MonoBehaviour {

	// Use this for initialization
	LobbyText[] playertext;

	int playernumber;
	
	void Start () {
		playertext = FindObjectsOfType<LobbyText> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnPhotonPlayerConnected (PhotonPlayer player)
	{
		if(PhotonNetwork.isMasterClient)
		{
			playernumber++;
			
		}
	}

	void OnPhotonPlayerDisconnected (PhotonPlayer player)
	{
		
	}



	/*IEnumerator checkPlayers()
	{
		yield return new WaitForSeconds(2f);
	}*/


	/*public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(level.changinglevel);
		}
		else
		{
			newLevel = (bool)stream.ReceiveNext();
		}
	}*/
}
