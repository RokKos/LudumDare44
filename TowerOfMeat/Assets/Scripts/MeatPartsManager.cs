using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPartsManager : MonoBehaviour
{

	[SerializeField] generateBlock GenerateBlock;
	[SerializeField] GameObject HighLine;
	private List<MeatPartController> meatPartsInScene = new List<MeatPartController>();

	delegate void MeatSucces (bool success);
	MeatSucces meatSucces;

	private void Start () {
		meatSucces += GenerateBlock.SetLastSuccess;
		HighLine.SetActive(false);
	}


	private void Update () {
		if (meatPartsInScene.Count > 0) {
			HighLine.SetActive(true);
			
			Vector3 topPos = new Vector3(0, GetMaxMeatHeight(), 0);
			HighLine.transform.position = topPos;
		}
	}
	public bool AddMeatPart (MeatPartController meatPart) {
		if (meatPartsInScene.Count == 0) {
			meatPartsInScene.Add(meatPart);
			meatSucces(true);
			return true;
		}


		MeatPartController topMeatPart = meatPartsInScene[meatPartsInScene.Count - 1];
		bool isOnTop = GetMaxMeatHeight() < meatPart.GetTopPointOfMeat();
		if (isOnTop) {
			meatPartsInScene.Add(meatPart);
			meatSucces(true);
			return true;
		} else {
			Destroy(meatPart.gameObject);
			meatSucces(false);
			return false;
		}
		
	}

	private float GetMaxMeatHeight () {
		float maxY = -float.MaxValue;
		foreach (MeatPartController meat in meatPartsInScene) {
			maxY = Mathf.Max(meat.GetTopPointOfMeat(), maxY);
		}
		return maxY;
	}
}
