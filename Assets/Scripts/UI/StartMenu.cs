using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button startButton;

    public void Start()
    {
        startButton.onClick.AddListener(GoToMainScene);
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
