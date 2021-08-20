using EndlessRunnerProject.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.UIs
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] GameOverPanel _gameOVerPanel;

        private void Awake()
        {
            _gameOVerPanel.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            GameManager.Instance.OnGameStop += HandleOnGameStop;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameStop -= HandleOnGameStop;
        }

        private void HandleOnGameStop()
        {
            _gameOVerPanel.gameObject.SetActive(true);
        }
    }
}