using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1;
    Camera viewCamera;
    Rigidbody rigidbodyPlayer;
    Vector3 velocity;
    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }
    private void FixedUpdate()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.fixedDeltaTime, 0, Input.GetAxisRaw("Vertical") * moveSpeed * Time.fixedDeltaTime);
    }
}
