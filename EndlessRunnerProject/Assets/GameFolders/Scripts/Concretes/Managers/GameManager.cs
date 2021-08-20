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
            Debug.Log("Yüklenecek sahne yüklendi");
            //Yükleme Ýþlemleri
        }
        public void ExitGame()
        {
            Debug.Log("Çýkýþ Baþarýlý");
            Application.Quit();
        }
    }
}