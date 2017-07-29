using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	private AudioSource audioSource;
	public AudioClip bounceClip;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playBounce()
	{
		audioSource.clip = bounceClip;
		audioSource.Play();
	}
}
