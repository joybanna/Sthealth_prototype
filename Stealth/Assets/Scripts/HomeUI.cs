using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeUI : MonoBehaviour
{
    public Button start_btn;
    private void Start()
    {
        start_btn.onClick.AddListener(() => SceneChange());
    }
    private void SceneChange()
    {
        SceneManager.LoadScene(1);
    }

}


