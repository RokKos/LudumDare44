using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropingController : MonoBehaviour
{
	//[SerializeField] List<MeatPartController> meatPartPrefab;
	[SerializeField] Transform gameTransform;
	[SerializeField] generateBlock GenerateBlock;

	[SerializeField] float movingBound;

	private Vector3 movingDir = Vector3.right;

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space)) {
			MeatPartController meatPart = GenerateBlock.GetBlock();
			meatPart.transform.SetParent(transform);
			meatPart.transform.localPosition = Vector3.zero;
			meatPart.transform.SetParent(gameTransform);
			meatPart.Setup(movingDir);
			meatPart.EnableGravity(true);
		}

		transform.position += movingDir * Time.deltaTime;
		if (Mathf.Abs(transform.position.x) > movingBound) {
			movingDir.x *= -1;
			transform.position += movingDir * Time.deltaTime;
		}
    }
}
