using EndlessRunnerProject.Abstacts.Utilities;
using EndlessRunnerProject.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Managers
{
    public class EnemyManager : SingletonMonoBehaviourObject<EnemyManager>
    {
        [SerializeField] EnemyController[] _enemyPrefabs;

        Queue<EnemyController> _enemies = new Queue<EnemyController>();

        private void Awake()
        {
            SingletonThisObject(this);
        }

        private void Start()
        {
            InitializePool();
        }

        void InitializePool()
        {
            for (int i = 0; i < 10; i++)
            {
                EnemyController newEnemy = Instantiate(_enemyPrefabs[Random.Range(0,_enemyPrefabs.Length)]);
                newEnemy.gameObject.SetActive(false);
                newEnemy.transform.parent = this.transform;
                _enemies.Enqueue(newEnemy);
            }
        }

        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;
            //enqueue = sýraya alma- havuza ekleme
            _enemies.Enqueue(enemyController);
        }

        public EnemyController GetPool()
        {
            if (_enemies.Count == 0)
            {
                InitializePool();
            }
            //dequeue = kuyruðu boþaltma - havuzdan çýkarma
            return _enemies.Dequeue();
        }
    }
}