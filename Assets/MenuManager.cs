using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	
	// Update is called once per frame
	public void Quit () {
		Debug.Log ("we quit");
		Application.Quit ();
	}
	
	public void ChangeLevel(string level_name)
	{
		Debug.Log ("change level");
		Application.LoadLevel (level_name);
	}
}
