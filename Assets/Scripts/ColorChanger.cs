using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorChanger : MonoBehaviour {
	Color ColorStart;
	Color ColorEnd;
	Text thecolor;
	// Use this for initialization
	void Start () {
		thecolor = transform.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ColorStart = thecolor.color;
		ColorEnd = new Color (Random.value, Random.value, Random.value);
		thecolor.color = Color.Lerp (ColorStart, ColorEnd, 1f);
	}
	
}
