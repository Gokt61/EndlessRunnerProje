using EndlessRunnerProject.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Controllers
{
    public class SpawnerController : MonoBehaviour
    {

        [Range(0.1f,5f)] [SerializeField] float _min = 0.1f;
        [Range(6f, 15f)] [SerializeField] float _max = 15f;
        
        float _maxSpawnTime;
        float _currentSpawnTime = 0f;

        private void OnEnable()
        {
            GetRandomMaxTime();
        }

        private void Update()
        {
            _currentSpawnTime += Time.deltaTime;

            if (_currentSpawnTime > _maxSpawnTime)
            {
                Spawn();
            }          
        }

        private void Spawn()
        {
            //Dusman olusturma islemi
            EnemyController newEnemy = EnemyManager.Instance.GetPool(); 
            newEnemy.transform.parent = this.transform;
            newEnemy.transform.position = this.transform.position;
            newEnemy.gameObject.SetActive(true);

            _currentSpawnTime = 0f;
            GetRandomMaxTime();
        }

        private void GetRandomMaxTime()
        {
            _maxSpawnTime = Random.Range(_min, _max);
        }
    }
}