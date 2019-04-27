using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPartController : MonoBehaviour
{

	[SerializeField] Rigidbody rigidbody;

	private Transform gameTransform;

	public void Setup (Vector3 movingDir) {
		rigidbody.AddForce(movingDir, ForceMode.Impulse);
	}

	private void OnCollisionEnter (Collision collision) {
		rigidbody.velocity = Vector3.zero;
		transform.SetParent(gameTransform);
	}

	public void EnableGravity (bool enable) {
		rigidbody.useGravity = enable;
	}
}
