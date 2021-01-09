using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBox : MonoBehaviour
{
    PlayerController playerController;
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triger");
        if (other.gameObject == playerController.gameObject)
        {
            other.GetComponent<PlayerController>().GameWin();
        }
    }
}
