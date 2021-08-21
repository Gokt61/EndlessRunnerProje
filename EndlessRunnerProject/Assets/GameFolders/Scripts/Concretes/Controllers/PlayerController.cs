using EndlessRunnerProject.Abstacts.Controllers;
using EndlessRunnerProject.Abstacts.Inputs;
using EndlessRunnerProject.Abstacts.Movements;
using EndlessRunnerProject.Inputs;
using EndlessRunnerProject.Managers;
using EndlessRunnerProject.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EndlessRunnerProject.Controllers
{
    public class PlayerController : MyCharacterController, IEntityController
    {
        [SerializeField] float _jumpForce = 300f;

        IJump _jump;
        IMover _mover;
        IInputReader _input;
        float _horizontal;
        bool _isJump;
        bool _isDead = false;


        private void Awake()
        {
            _mover = new HorizontalMover(this);
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
            _mover.FixedTick(_horizontal);

            if (_isJump)
            {
                _jump.FixedTick(_jumpForce);
            }
            _isJump = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            IEntityController entityController = other.GetComponent<IEntityController>();

            if (entityController != null)
            {
                _isDead = true;
                GameManager.Instance.StopGame();
            }
        }
    }
}