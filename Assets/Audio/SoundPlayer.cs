using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip clip;

    void Start()
    {
        clip.Play();
    }
}