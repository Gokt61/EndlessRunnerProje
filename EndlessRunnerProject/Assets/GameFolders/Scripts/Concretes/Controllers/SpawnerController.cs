using EndlessRunnerProject.Enums;
using EndlessRunnerProject.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        //[SerializeField] EnemyController _enemyPrefab; bu yapýyý enemyManagerý yazdýk.

        [Range(0.1f,5f)] [SerializeField] float _min = 0.1f;
        [Range(6f, 15f)] [SerializeField] float _max = 15f;
        
        float _maxSpawnTime;
        float _currentSpawnTime = 0f;
        float _index = 0f;
        float _maxAddEnemyTime;

        public bool CanIncrease => _index < EnemyManager.Instance.Count;

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

            if (!CanIncrease) return;

            if (_maxAddEnemyTime < Time.time)
            {
                _maxAddEnemyTime = Time.time + EnemyManager.Instance.AddDelayTime;
                IncreaseIndex();
                //Index artýþ
            }
        }

        private void Spawn()
        {
            //Dusman olusturma islemi
            //EnemyController newEnemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
            //newEnemy.transform.parent = this.transform;

            EnemyController newEnemy = EnemyManager.Instance.GetPool((EnemyEnum)Random.Range(0,_index));
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

        void IncreaseIndex()
        {
            if (CanIncrease)
            {
                _index++;
            }
        }
    }
}