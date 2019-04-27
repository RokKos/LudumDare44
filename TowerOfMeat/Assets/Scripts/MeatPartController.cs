using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPartController : MonoBehaviour
{

	[SerializeField] Rigidbody rigidbody;

	private Transform gameTransform;

	public void Setup (Transform _gameTransform) {
		gameTransform = _gameTransform;
	}

	private void OnCollisionEnter (Collision collision) {
		rigidbody.velocity = Vector3.zero;
		transform.SetParent(gameTransform);
	}
}
