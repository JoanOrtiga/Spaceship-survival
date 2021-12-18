using System;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipSurvival.Pause
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;

        public void Pause()
        {
            GameController.Instance.SetGamePause(true);
            pauseMenu.SetActive(true);
        }

        public void UnPause()
        {
            GameController.Instance.SetGamePause(false);
            pauseMenu.SetActive(false);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
