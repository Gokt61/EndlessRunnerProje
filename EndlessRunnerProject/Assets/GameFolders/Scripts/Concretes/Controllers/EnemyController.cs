using EndlessRunnerProject.Abstacts.Controllers;
using EndlessRunnerProject.Enums;
using EndlessRunnerProject.Managers;
using EndlessRunnerProject.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Controllers
{
    public class EnemyController : MyCharacterController, IEntityController
    {
        [SerializeField] float _maxLifeTime = 10f;
        [SerializeField] EnemyEnum _enemyEnum;

        VerticalMover _mover;
        float currentLifeTime = 0f;

        public EnemyEnum EnemyType => _enemyEnum;


        private void Awake()
        {
            _mover = new VerticalMover(this);
        }
        private void Update()
        {
            currentLifeTime += Time.deltaTime;

            if (currentLifeTime > _maxLifeTime)
            {
                currentLifeTime = 0f;
                KillYourSelf();
            }
        }

        private void FixedUpdate()
        {
            _mover.FixedTick();
        }

        private void KillYourSelf()
        {
            //Destroy(this.gameObject);
            EnemyManager.Instance.SetPool(this);
        }
    }
}