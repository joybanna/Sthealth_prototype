using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    PlayerController playerController;
    public bool isDetect;
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerController.gameObject)
        {
            Debug.Log("coll");
            playerController.ChangeDetect(isDetect);
            this.gameObject.SetActive(false);
        }

    }

}
