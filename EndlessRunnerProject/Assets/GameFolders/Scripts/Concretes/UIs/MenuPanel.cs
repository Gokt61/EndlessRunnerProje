using EndlessRunnerProject.Managers;
using System.Collections;
using System.Collections.Generic;
using EndlessRunnerProject.Managers;
using UnityEngine;

namespace EndlessRunnerProject.UIs
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartButton()
        {
            GameManager.Instance.LoadScene();
        }
        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
        }
    }
}