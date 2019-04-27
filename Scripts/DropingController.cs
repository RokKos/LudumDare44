using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropingController : MonoBehaviour
{
	[SerializeField] MeatPartController meatPartPrefab;

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space)) {
			MeatPartController meatPart = Instantiate(meatPartPrefab, Vector3.zero, Quaternion.identity, transform);
		}
    }
}
