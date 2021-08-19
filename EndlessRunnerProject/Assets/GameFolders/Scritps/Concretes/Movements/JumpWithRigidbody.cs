using EndlessRunnerProject.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Movements
{
    public class JumpWithRigidbody
    {
        Rigidbody _rigidboyd;
        public bool CanJump => _rigidboyd.velocity.y != 0;

        public JumpWithRigidbody(PlayerController playerController)
        {
            _rigidboyd = playerController.GetComponent<Rigidbody>();
        }

        public void TickFixed(float jumpForce)
        {
            if (CanJump) return;

            _rigidboyd.velocity = Vector3.zero;
            _rigidboyd.AddForce(Vector3.up * Time.deltaTime * jumpForce);
        }
    }
}