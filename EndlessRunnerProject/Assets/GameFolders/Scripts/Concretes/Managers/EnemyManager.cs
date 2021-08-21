using EndlessRunnerProject.Abstacts.Utilities;
using EndlessRunnerProject.Controllers;
using EndlessRunnerProject.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Managers
{
    public class EnemyManager : SingletonMonoBehaviourObject<EnemyManager>
    {
        [SerializeField] float _addDelatTime = 50f;
        [SerializeField] EnemyController[] _enemyPrefabs;

        Dictionary<EnemyEnum, Queue<EnemyController>> _enemies = new Dictionary<EnemyEnum, Queue<EnemyController>>();

        public float AddDelayTime => _addDelatTime;

        public float Count => _enemyPrefabs.Length;

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
            for (int i = 0; i < _enemyPrefabs.Length; i++)
            {
                Queue<EnemyController> enemyControllers = new Queue<EnemyController>();

                for (int j = 0; j < 10; j++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[i]);
                    newEnemy.gameObject.SetActive(false);
                    newEnemy.transform.parent = this.transform;
                    enemyControllers.Enqueue(newEnemy);
                }
                _enemies.Add((EnemyEnum)i, enemyControllers);
            }
        }

        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;
            //enqueue = sýraya alma- havuza ekleme
            //_enemies.Enqueue(enemyController);

            Queue<EnemyController> enemyControllers = _enemies[enemyController.EnemyType];
            enemyControllers.Enqueue(enemyController);
        }

        public EnemyController GetPool(EnemyEnum enemyType)
        {
            //if (_enemies.Count == 0)
            //{
            //    InitializePool();
            //}
            //dequeue = kuyruðu boþaltma - havuzdan çýkarma
            //return _enemies.Dequeue();

            Queue<EnemyController> enemyControllers = _enemies[enemyType];

            if (enemyControllers.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[(int)enemyType]);
                    enemyControllers.Enqueue(newEnemy);
                }
            }

            return enemyControllers.Dequeue();
        }
    }
}