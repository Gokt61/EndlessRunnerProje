using EndlessRunnerProject.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Controllers
{
    public class PlayerControllers : MonoBehaviour
    {
        [SerializeField] float _horizontalDirection = 0f;
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _jumpForce = 300f;
        [SerializeField] bool _isJump;

        JumpWithRigidbody _jump;
        HorizontalMover _horizontalMover;

        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jump = new JumpWithRigidbody(this);
        }

        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(_horizontalDirection, _moveSpeed);

            if (_isJump)
            {
                _jump.TickFixed(_jumpForce);
            }
            _isJump = false;
        }
    }
}