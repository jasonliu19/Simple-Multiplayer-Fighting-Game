using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float jumpspeed;
	bool grounded;
	float movey = 0;
	float movex = 0;
	public bool facingRight = true;
	Animator anim;
	// Use this for initialization

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (Input.GetKey (KeyCode.A))
		{
			movex = -1;
			if (facingRight)
				Flip();
		}
		else if (Input.GetKey (KeyCode.D))
		{
			movex = 1;
			if (!facingRight)
				Flip();
		}
		else
			movex = 0;

		if (Input.GetKey (KeyCode.W) && grounded) {
			movey = 1;
			grounded = false;
		}
		
		if (!grounded)
		{
			movey -= 0.05f;
		}
		else
		{
			movey = 0;
		}

		anim.SetFloat("Speed", Mathf.Abs(movex) + movey);


		GetComponent<Rigidbody2D>().velocity = new Vector2 (movex * speed, movey * jumpspeed);

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground")
		{
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground")
		{
			grounded = false;
		}
	}

	void Flip()
	{
		facingRight = !facingRight;

		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	
}
