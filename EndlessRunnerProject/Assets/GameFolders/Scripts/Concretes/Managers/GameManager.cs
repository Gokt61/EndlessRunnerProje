using EndlessRunnerProject.Abstacts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Managers
{
    public class GameManager : SingletonMonoBehaviourObject<GameManager>
    {
        private void Awake()
        {
            SingletonThisObject(this);
        }

        public void StopGame()
        {
            Time.timeScale = 0f;
        }

        public void LoadScene()
        {
            Debug.Log("Y�klenecek sahne y�klendi");
            //Y�kleme ��lemleri
        }
        public void ExitGame()
        {
            Debug.Log("��k�� Ba�ar�l�");
            Application.Quit();
        }
    }
}