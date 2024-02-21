using UnityEngine;

[ RequireComponent( typeof( Rigidbody2D ) ) ]
public class PhysicsSoundPlayer : MonoBehaviour
{
    public AudioClip bumpSound;
    public float bumpVolume = 1;
    public float minBumpSpeed = 1;
    public float maxBumpSpeed = 10;

    //public AudioClip slideSound;

    void OnCollisionEnter2D(Collision2D other)
    {
        var speed = other.relativeVelocity.magnitude;
        var ratio = Mathf.InverseLerp(minBumpSpeed, maxBumpSpeed, speed);
        var volume = ratio * ratio * bumpVolume;
        bumpSound.Play(volume);
    }
}