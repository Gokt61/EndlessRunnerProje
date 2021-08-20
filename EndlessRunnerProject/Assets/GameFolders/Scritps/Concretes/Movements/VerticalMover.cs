using EndlessRunnerProject.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Movements
{
    public class VerticalMover
    {
        EnemyController _enemyController;
        float _moveSpeed;
        public VerticalMover(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _moveSpeed = enemyController.MoveSpeed;
        }

        public void FixedTick()
        {
            _enemyController.transform.Translate(Vector3.back * _moveSpeed * Time.deltaTime);
        }
    }
}