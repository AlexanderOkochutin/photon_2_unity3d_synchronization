using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Gun : MonoBehaviour {

	public Transform player;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	public float bulletForce;

	public float cooldownTime;

	private float nextTimeToShoot;

	// Use this for initialization
	void Start () {
		nextTimeToShoot = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (player.GetComponent<PlayerController>().photonView.IsMine && Input.GetMouseButton (0)) {
			if (Time.time > nextTimeToShoot) {
				nextTimeToShoot = Time.time + cooldownTime;
				var go = PhotonNetwork.Instantiate("Bullet",bulletSpawn.position, Quaternion.identity);
				go.GetComponent<Rigidbody> ().velocity = player.GetComponent<Rigidbody>().velocity;
				go.GetComponent<Rigidbody> ().AddForce (player.up * bulletForce);
				Destroy (go, 2);
			}
		}
	}
}