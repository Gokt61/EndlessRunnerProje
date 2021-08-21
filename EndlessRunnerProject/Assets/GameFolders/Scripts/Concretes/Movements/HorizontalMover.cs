using EndlessRunnerProject.Abstacts.Controllers;
using EndlessRunnerProject.Abstacts.Movements;
using EndlessRunnerProject.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Movements
{
    public class HorizontalMover : IMover
    {
        IEntityController _playerController;
        float _moveSpeed;
        float _moveBoundary;

        public HorizontalMover(IEntityController playerController)
        {
            _playerController = playerController;
            //_moveSpeed = playerController.MoveSpeed;
            //_moveBoundary = playerController.MoveBoundary;

        }

        public void FixedTick(float horizontal)
        {
            if (horizontal == 0f) return;

            _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _moveSpeed);

            float xBoundary = Mathf.Clamp(_playerController.transform.position.x, -_moveBoundary, _moveBoundary);
            _playerController.transform.position = new Vector3(xBoundary, _playerController.transform.position.y, 0f);
        }
    }
}