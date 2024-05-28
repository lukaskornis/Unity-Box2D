using UnityEngine;

[ExecuteAlways]
public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
public Vector3 offset;


void Start()
{
    Application.targetFrameRate = 60;
}

void LateUpdate()
    {
        if (!target) return;

        var targetPos = target.position + offset;
        targetPos.z = transform.position.z;
        var smoothPos = Vector3.Lerp(transform.position, targetPos, smoothTime);
        transform.position = smoothPos;
    }
}