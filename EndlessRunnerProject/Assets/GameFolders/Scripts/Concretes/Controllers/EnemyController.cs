using EndlessRunnerProject.Managers;
using EndlessRunnerProject.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 10;
        [SerializeField] float _maxLifeTime = 10f;

        VerticalMover _mover;
        float currentLifeTime = 0f;

        public float MoveSpeed => _moveSpeed;

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
            EnemyManager.Instance.SetPool(this);
        }
    }
}