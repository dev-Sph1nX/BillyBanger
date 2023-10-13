using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public Button againButton;

    public void Start()
    {
        againButton.onClick.AddListener(GoToMenuScene);
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
