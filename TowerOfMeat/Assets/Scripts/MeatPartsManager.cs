using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPartsManager : MonoBehaviour
{

	[SerializeField] generateBlock GenerateBlock;
	[SerializeField] HighLine highLine;
	[SerializeField] float bufferOffset;

	private List<MeatPartController> meatPartsInScene = new List<MeatPartController>();

	delegate void MeatSucces (bool success);
	MeatSucces meatSucces;

	private void Start () {
		meatSucces += GenerateBlock.SetLastSuccess;
		highLine.gameObject.SetActive(false);
	}


	private void Update () {
		if (meatPartsInScene.Count > 0) {
			highLine.gameObject.SetActive(true);
			
			Vector3 topPos = new Vector3(0, GetMaxMeatHeight() + highLine.GetExtendsHeight(), 0);
			highLine.transform.position = topPos;
		}
	}
	public bool AddMeatPart (MeatPartController meatPart) {
		if (meatPartsInScene.Count == 0) {
			meatPartsInScene.Add(meatPart);
			meatSucces(true);
			return true;
		}


		MeatPartController topMeatPart = meatPartsInScene[meatPartsInScene.Count - 1];
		bool isOnTop = GetMaxMeatHeight() < meatPart.GetTopPointOfMeat() + bufferOffset;
		if (isOnTop) {
			meatPartsInScene.Add(meatPart);
			meatSucces(true);
			return true;
		} else {
			meatPartsInScene.Remove(meatPart);
			Destroy(meatPart.gameObject);
			meatSucces(false);
			return false;
		}
		
	}

	public float GetMaxMeatHeight () {
		float maxY = -float.MaxValue;
		foreach (MeatPartController meat in meatPartsInScene) {
			maxY = Mathf.Max(meat.GetTopPointOfMeat(), maxY);
		}
		return maxY;
	}
}
