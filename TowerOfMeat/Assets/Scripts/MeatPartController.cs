using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPartController : MonoBehaviour
{

	[SerializeField] Rigidbody rigidbody;

	private void OnCollisionEnter (Collision collision) {
		rigidbody.velocity = Vector3.zero;
	}
}
