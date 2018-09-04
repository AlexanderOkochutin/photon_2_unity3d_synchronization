using System.Collections;
using UnityEngine;

public class LookAtMouse : MonoBehaviour {
	void FixedUpdate () {
		if (GetComponent<PlayerController> ().photonView.IsMine) {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePosition.z = 0;
			Vector3 diraction = mousePosition - transform.position;
			this.transform.up = diraction;
		}
	}
}