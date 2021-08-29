using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsOptions : MonoBehaviour
{
    public GameObject optionsPanel;
    public void ExitOptions()
    {
        optionsPanel.SetActive(false);
    }
}
