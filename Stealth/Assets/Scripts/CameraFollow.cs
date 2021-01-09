using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private float minzoom = 11;
    private float maxzoom = 22;
    private Camera cameraMain;
    private void Start()
    {
        cameraMain = Camera.main;
    }
    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            if (cameraMain.orthographicSize < maxzoom && cameraMain.orthographicSize > minzoom)
            {
                cameraMain.orthographicSize -= Input.mouseScrollDelta.y;
            }
            else
            {
                if (cameraMain.orthographicSize <= maxzoom && Input.mouseScrollDelta.y < 0)
                {
                    cameraMain.orthographicSize -= Input.mouseScrollDelta.y;
                }
                else if (cameraMain.orthographicSize >= minzoom && Input.mouseScrollDelta.y > 0)
                {
                    cameraMain.orthographicSize -= Input.mouseScrollDelta.y;
                }
            }
        }
    }
    private void LateUpdate()
    {
        Vector3 dirPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, dirPos, smoothSpeed);
        transform.position = smoothPos;
    }
}
