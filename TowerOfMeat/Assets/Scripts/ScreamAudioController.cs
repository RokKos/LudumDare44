using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamAudioController : MonoBehaviour
{
	[SerializeField] AudioSource audioSource;
	[SerializeField] List<AudioClip> screams;

	public void PlayScream () {
		AudioClip clip = screams[Random.Range(0, screams.Count)];
		audioSource.clip = clip;
		audioSource.Play();

	}

}
