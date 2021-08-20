using EndlessRunnerProject.Abstacts.Inputs;
using EndlessRunnerProject.Inputs;
using EndlessRunnerProject.Managers;
using EndlessRunnerProject.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EndlessRunnerProject.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveBoundary = 4.5f;
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _jumpForce = 300f;

        JumpWithRigidbody _jump;
        HorizontalMover _horizontalMover;
        IInputReader _input;
        float _horizontal;
        bool _isJump;
        bool _isDead = false;

        public float MoveSpeed => _moveSpeed;
        public float MoveBoundary => _moveBoundary;

        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jump = new JumpWithRigidbody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }

        private void Update()
        {
            if (_isDead) return;

            _horizontal = _input.Horizontal;

            if (_input.IsJump)
            {
                _isJump = true;
            }      
        }

        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(_horizontal);

            if (_isJump)
            {
                _jump.TickFixed(_jumpForce);
            }
            _isJump = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();

            if (enemyController != null)
            {
                _isDead = true;
                GameManager.Instance.StopGame();
            }
        }
    }
}