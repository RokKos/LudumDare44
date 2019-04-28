using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSplatterController : MonoBehaviour
{

	[SerializeField] AudioSource audioSource;
	[SerializeField] List<AudioClip> splatters;

	public void PlaySplatter () {
		AudioClip clip = splatters[Random.Range(0, splatters.Count)];
		audioSource.clip = clip;
		audioSource.Play();

	}
}
