using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropingController : MonoBehaviour
{
	[SerializeField] List<MeatPartController> meatPartPrefab;
	[SerializeField] Transform gameTransform;

	[SerializeField] float movingBound;

	[SerializeField] string s;

	private Vector3 movingDir = Vector3.right;

	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space)) {
			MeatPartController meatPart = Instantiate(meatPartPrefab[0], transform);
			meatPart.transform.localPosition = Vector3.zero;
			meatPart.Setup(gameTransform);
		}

		transform.position += movingDir * Time.deltaTime;
		if (Mathf.Abs(transform.position.x) > movingBound) {
			movingDir.x *= -1;
			transform.position += movingDir * Time.deltaTime;
		}
    }
}
