﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;

	void Start ()
	{
		count = 0;
		setCountText ();
		winText.text = "";
	}

	void setCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 16)
			winText.text = "You Win";
	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other)
		{
		if (other.gameObject.tag == "Pickup")
			other.gameObject.SetActive (false);
			count++;
			setCountText ();
		}
		

}
