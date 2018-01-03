using UnityEngine;
using System.Collections;

public class FalconPunchSpawn : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	public float cooldown = 3;
	private PlayerMovement playerCtrl;

	void Start () {
		anim = transform.root.GetComponent<Animator> ();
		playerCtrl = transform.root.GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		cooldown += Time.deltaTime;
		if (Input.GetKey (KeyCode.E) && cooldown > 2.5f){
			anim.SetTrigger("Punch");
			if (playerCtrl.facingRight)
				PhotonNetwork.Instantiate("dude_arm", transform.position, Quaternion.identity, 0);
			else
				PhotonNetwork.Instantiate("dude_arm", transform.position, Quaternion.Euler(new Vector3(0f,0f,180f)), 0);
			cooldown = 0;
		}

	}
	
}
