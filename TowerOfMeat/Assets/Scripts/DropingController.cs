using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropingController : MonoBehaviour
{
	//[SerializeField] List<MeatPartController> meatPartPrefab;
	[SerializeField] Transform gameTransform;
	[SerializeField] generateBlock GenerateBlock;
	[SerializeField] MeatPartsManager meatPartsManager;
	[SerializeField] GameController gameController;


	[SerializeField] float movingBound;
	[SerializeField] float movingSpeed;

	private Vector3 movingDir = Vector3.right;
	private float timeFromLastDrop = 0;

	private void Start () {
		timeFromLastDrop = 0;
	}

	// Update is called once per frame
	private void Update ()
    {
		timeFromLastDrop += Time.deltaTime;
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && timeFromLastDrop > gameController.GetRateOfDroping()) {
			MeatPartController meatPart = GenerateBlock.GetBlock();
			meatPart.transform.SetParent(transform);
			meatPart.transform.localPosition = Vector3.zero;
			meatPart.transform.SetParent(gameTransform);
			meatPart.Setup(movingDir, meatPartsManager);
			meatPart.EnableGravity(true);
			timeFromLastDrop = 0;
		}

		transform.position += movingDir * movingSpeed * Time.deltaTime;
		if (Mathf.Abs(transform.position.x) > movingBound) {
			movingDir.x *= -1;
			transform.position += movingDir * Time.deltaTime;
		}
    }
}

