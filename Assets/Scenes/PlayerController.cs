using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float scaleVelocity;
	public float force = 10f;
	public Rigidbody rigidbody;
	public PhotonView photonView;

	void Awake () {
		rigidbody = GetComponent<Rigidbody> ();
		photonView = GetComponent<PhotonView> ();
	}

	void Update () {
		if (photonView.IsMine) {
			InputOfPlayer ();
		}
	}

	void InputOfPlayer () {
		if (Input.GetKey (KeyCode.W))
			rigidbody.AddForce (Vector3.up * force);

		if (Input.GetKey (KeyCode.S))
			rigidbody.AddForce (Vector3.down * force);

		if (Input.GetKey (KeyCode.D))
			rigidbody.AddForce (Vector3.right * force);

		if (Input.GetKey (KeyCode.A))
			rigidbody.AddForce (Vector3.left * force);
		if (Input.GetKey (KeyCode.KeypadPlus))
			this.transform.localScale += Vector3.one * scaleVelocity * Time.deltaTime;
		if (Input.GetKey (KeyCode.KeypadMinus))
			this.transform.localScale -= Vector3.one * scaleVelocity * Time.deltaTime;

	}
}