using UnityEngine;

public class Audio : Singleton<Audio>
{
	AudioSource source;

	void Awake()
	{
		source = gameObject.AddComponent<AudioSource>();
	}

	public void Play(AudioClip clip, float volume = 1f)
	{
		source.PlayOneShot( clip,volume);

	}
}