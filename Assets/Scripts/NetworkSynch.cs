using UnityEngine;
using System.Collections;

public class NetworkSynch : Photon.MonoBehaviour {
	
	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;
	Vector2 realVelocity;
	Animator anim;
	bool facingRight = true;
	bool punching = false;
	FalconPunchSpawn punchanimation;
	// Use this for initialization
	void Start () {
		punchanimation = transform.root.GetComponentInChildren<FalconPunchSpawn> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (photonView.isMine) {
		} 
		else 
		{
			if (transform.position.x - realPosition.x > 0.3 || transform.position.x - realPosition.x < -0.3 || transform.position.y - realPosition.y > 0.3 || transform.position.y - realPosition.y < -0.3)
				transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);

			transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);
			GetComponent<Rigidbody2D>().velocity = realVelocity;
			anim = GetComponent<Animator> ();
			anim.SetFloat("Speed", Mathf.Abs(realVelocity.x) + realVelocity.y);

			if (punching)
				anim.SetTrigger("Punch");

			if (!facingRight && transform.localScale.x > 0)
			{
				Debug.Log("we flip");
				Vector3 scale = transform.localScale;
				scale.x *= -1;
				transform.localScale = scale;
			}
			else if (facingRight && transform.localScale.x < 0)
			{
				Vector3 scale = transform.localScale;
				scale.x *= -1;
				transform.localScale = scale;
			}
		}
	}
	
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) 
		{
			//Our player

			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);


			stream.SendNext(GetComponent<Rigidbody2D>().velocity);
			if (transform.localScale.x > 0)
				stream.SendNext(true);
			else
				stream.SendNext(false);

			if (punchanimation.cooldown < 0.2)
				stream.SendNext(true);
			else
				stream.SendNext(false);
		}
		else
		{
			//Other players
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();

			realVelocity = (Vector2)stream.ReceiveNext();
			facingRight = (bool)stream.ReceiveNext();
			punching = (bool)stream.ReceiveNext();
		}
	}
}
