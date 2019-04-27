using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLine : MonoBehaviour
{
	[SerializeField] MeshRenderer meshRenderer;

	public float GetExtendsHeight () {
		return meshRenderer.bounds.extents.y;
	}
}
