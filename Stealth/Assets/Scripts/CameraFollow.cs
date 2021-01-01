using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private void LateUpdate()
    {
        Vector3 dirPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, dirPos, smoothSpeed);
        transform.position = smoothPos;
    }
}
