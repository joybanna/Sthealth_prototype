using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1;
    private Camera viewCamera;
    public bool isDetect;
    private int state;
    private StateController stateController;
    void Start()
    {
        state = 0;
        stateController = FindObjectOfType<StateController>();
        viewCamera = Camera.main;
        isDetect = false;
        stateController.SetIconVisible(isDetect);
        Time.timeScale = 1;
    }
    private void FixedUpdate()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.fixedDeltaTime, 0, Input.GetAxisRaw("Vertical") * moveSpeed * Time.fixedDeltaTime);
    }
    public void GameOver()
    {
        if (isDetect)
        {
            Debug.Log("game over");
            Time.timeScale = 0;
            stateController.SetPanelGameOver();
        }
    }
    public void ChangeDetect(bool _isdetect)
    {
        isDetect = _isdetect;
        stateController.SetIconVisible(_isdetect);
        if (_isdetect)
        {
            state++;
        }
        else
        {
            //setactive old state & open new state         
            stateController.SetState(state, false, 1f);
            stateController.SetState(state + 1, true, 0.5f);
        }
    }
    public void GameWin()
    {
        stateController.GameWinPanel();
    }

}
