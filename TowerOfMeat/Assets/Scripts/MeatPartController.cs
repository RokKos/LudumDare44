using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPartController : MonoBehaviour {

	[SerializeField] Rigidbody rigidbody;
	[SerializeField] MeshRenderer mr;

	private MeatPartsManager meatPartsManager;
	private bool firstHit = true;

	private const string kAltarTag = "Altar";

	public void Setup (Vector3 movingDir, MeatPartsManager _meatPartsManager) {
		rigidbody.AddForce(movingDir, ForceMode.Impulse);
		meatPartsManager = _meatPartsManager;
		firstHit = true;
	}

	private void OnCollisionEnter (Collision collision) {
		if (!firstHit && collision.collider.tag == kAltarTag) {
			// This will fail
			firstHit = meatPartsManager.AddMeatPart(this);
		}


		if (firstHit) {
			rigidbody.velocity = Vector3.zero;
			meatPartsManager.AddMeatPart(this);
			firstHit = false;
		}
		
	}

	public void EnableGravity (bool enable) {
		rigidbody.useGravity = enable;
	}

	public float GetTopPointOfMeat () {
		return transform.position.y + mr.bounds.extents.y;
	}
}
