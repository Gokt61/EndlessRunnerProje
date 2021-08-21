using EndlessRunnerProject.Abstacts.Controllers;
using EndlessRunnerProject.Abstacts.Movements;
using EndlessRunnerProject.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Movements
{
    public class VerticalMover : IMover
    {
        IEntityController _entityController;
        float _moveSpeed;
        public VerticalMover(IEntityController entityController)
        {
            _entityController = entityController;
            _moveSpeed = entityController.MoveSpeed;
        }

        public void FixedTick(float vertical = 1)
        {
            _entityController.transform.Translate(Vector3.back * _moveSpeed * Time.deltaTime);
        }
    }
}