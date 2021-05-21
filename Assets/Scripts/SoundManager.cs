using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {
	public static SoundManager instance;

	public AudioClip jump;
	public AudioClip click;
	public AudioClip walking;

	private bool muted;
	private AudioSource audioSource;
	public AudioSource effectsSource;

	// Use this for initialization
	void Awake () {
		if (instance == null)
        {
			instance = this;
			DontDestroyOnLoad(gameObject);
        }
		else
        {
			Destroy(gameObject);
        }

		audioSource = GetComponent<AudioSource>();
	}

	public void ToggleMuted()
    {
		muted = !muted;
		audioSource.mute = muted;
    }

	public bool GetMuted()
    {
		return muted;
    }

	public void PlayJump()
    {
		if (muted == false)
        {
			effectsSource.PlayOneShot(jump, 1f);
        }
    }

	public void PlayClick()
    {
		if (muted == false)
        {
			effectsSource.PlayOneShot(click, 1f);
        }
    }
}
