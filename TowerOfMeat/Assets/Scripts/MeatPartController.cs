using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPartController : MonoBehaviour {

	[SerializeField] Rigidbody rigidbody;
	[SerializeField] MeshRenderer mr;
	[SerializeField] GameObject bloodSplat;

	private MeatPartsManager meatPartsManager;
	private bool firstHit = true;

	private const string kAltarTag = "Altar";

	public void Setup (Vector3 movingDir, MeatPartsManager _meatPartsManager) {
		rigidbody.AddForce(movingDir, ForceMode.Impulse);
		meatPartsManager = _meatPartsManager;
		firstHit = true;
	}

	private void OnCollisionEnter (Collision collision) {
		//if (firstHit && collision.collider.tag == kAltarTag) {
		//	meatPartsManager.AddMeatPart(this);
		//}



		if (firstHit) {
			rigidbody.velocity = Vector3.zero;
			meatPartsManager.AddMeatPart(this);
			firstHit = false;
			GameObject bS = Instantiate(bloodSplat, transform);
			bS.transform.position = Vector3.zero;
			Destroy(bS, 1);
		}
		
	}

	public void EnableGravity (bool enable) {
		rigidbody.useGravity = enable;
	}

	public float GetTopPointOfMeat () {
		return transform.position.y + mr.bounds.extents.y;
	}
}
