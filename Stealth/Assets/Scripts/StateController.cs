using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StateController : MonoBehaviour
{
    public GameObject[] stategame;
    public Image image;
    public GameObject panel_lose;
    public GameObject panel_win;
    public Sprite visible;
    public Sprite invisible;
    public Button[] home_btn;
    private void Start()
    {
        panel_lose.SetActive(false);
        panel_win.SetActive(false);
        for (var i = 0; i < home_btn.Length; i++)
        {
            home_btn[i].onClick.AddListener(() => OnclickHome());
        }

        /*for (int i = 1; i < stategame.Length; i++)
        {
            stategame[i].SetActive(false);
        }*/
    }
    public void SetState(int _state, bool _isOpen, float _time)
    {
        StartCoroutine(DelayChangeState(_state, _isOpen, _time));
    }
    IEnumerator DelayChangeState(int _state, bool _isOpen, float _time)
    {
        yield return new WaitForSeconds(_time);
        stategame[_state].SetActive(_isOpen);
    }
    public void SetPanelGameOver()
    {
        panel_lose.SetActive(true);
    }
    public void SetIconVisible(bool _isDetect)
    {
        if (_isDetect)
        {
            image.sprite = visible;
        }
        else
        {
            image.sprite = invisible;
        }
    }
    private void OnclickHome()
    {
        SceneManager.LoadScene(0);
    }
    public void GameWinPanel()
    {
        Debug.Log("win");
        panel_win.SetActive(true);
    }
}
