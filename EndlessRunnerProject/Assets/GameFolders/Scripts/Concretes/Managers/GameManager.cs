using EndlessRunnerProject.Abstacts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndlessRunnerProject.Managers
{
    public class GameManager : SingletonMonoBehaviourObject<GameManager>
    {
        public event System.Action OnGameStop;

        private void Awake()
        {
            SingletonThisObject(this);
        }

        public void StopGame()
        {
            OnGameStop?.Invoke();
            Time.timeScale = 0f;
            //if (OnGameStop != null)
            //{
            //    OnGameStop();
            //}
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            Time.timeScale = 1f;
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
        public void ExitGame()
        {
            Debug.Log("Çýkýþ Baþarýlý");
            Application.Quit();
        }
    }
}