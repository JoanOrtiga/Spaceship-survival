using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsMenu : MonoBehaviour
{
    public GameObject optionsPanel;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void EnterOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
