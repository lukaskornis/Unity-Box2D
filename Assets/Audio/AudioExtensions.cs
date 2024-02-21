using UnityEngine;

public static class AudioExtensions{
	public static void Play(this AudioClip clip, float volume = 1)
	{
		Audio.Instance.Play(clip, volume);
	}
}