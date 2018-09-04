using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.UtilityScripts {
	public class TestOnJoinedInstantiate : MonoBehaviour, IConnectionCallbacks, IMatchmakingCallbacks, ILobbyCallbacks {

		public Material mineMaterial;

		public Transform SpawnPosition;
		public float PositionOffset = 2.0f;
		public GameObject[] PrefabsToInstantiate; // set in inspector

		public virtual void OnEnable () {
			PhotonNetwork.AddCallbackTarget (this);
		}

		public virtual void OnDisable () {
			PhotonNetwork.RemoveCallbackTarget (this);
		}

		public void OnConnected () {

		}

		public void OnConnectedToMaster () {
			Debug.Log("onconnected master");
		}

		public void OnCreatedRoom () {

		}

		public void OnCreateRoomFailed (short returnCode, string message) {

		}

		public void OnCustomAuthenticationFailed (string debugMessage) {

		}

		public void OnCustomAuthenticationResponse (Dictionary<string, object> data) {

		}

		public void OnDisconnected (DisconnectCause cause) {

		}

		public void OnFriendListUpdate (List<FriendInfo> friendList) {

		}

		public void OnJoinedRoom () {
			Debug.Log("JOINED ROOM");
			if (this.PrefabsToInstantiate != null) {
				foreach (GameObject o in this.PrefabsToInstantiate) {
					Debug.Log ("Instantiating: " + o.name);

					Vector3 spawnPos = Vector3.up;
					if (this.SpawnPosition != null) {
						spawnPos = this.SpawnPosition.position;
					}

					Vector3 random = Random.insideUnitCircle;
					random.y = 0;
					random = random.normalized;
					Vector3 itempos = spawnPos + this.PositionOffset * random;

					var t = PhotonNetwork.Instantiate (o.name, itempos, Quaternion.identity, 0);
					t.GetComponent<Rigidbody> ().isKinematic = true;
					if (t.GetComponent<PlayerController> ().photonView.IsMine) {
						t.GetComponent<Rigidbody> ().isKinematic = false;
						Camera.main.GetComponent<CompleteCameraController> ().player = t;
					}
				}
			}
		}

		public void OnJoinRandomFailed (short returnCode, string message) {

		}

		public void OnJoinRoomFailed (short returnCode, string message) {

		}

		public void OnLeftRoom () {

		}

		public void OnRegionListReceived (RegionHandler regionHandler) {

		}

		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {

		}

		public void OnJoinedLobby () {
			throw new System.NotImplementedException ();
		}

		public void OnLeftLobby () {
			throw new System.NotImplementedException ();
		}

		public void OnRoomListUpdate (List<RoomInfo> roomList) {
			throw new System.NotImplementedException ();
		}

		public void OnLobbyStatisticsUpdate (List<TypedLobbyInfo> lobbyStatistics) {
			throw new System.NotImplementedException ();
		}
	}
}