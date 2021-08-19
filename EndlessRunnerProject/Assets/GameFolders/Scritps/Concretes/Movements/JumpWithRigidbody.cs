using EndlessRunnerProject.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Movements
{
    public class JumpWithRigidbody
    {
        Rigidbody _rigidboyd;

        public JumpWithRigidbody(PlayerControllers playerController)
        {
            _rigidboyd = playerController.GetComponent<Rigidbody>();
        }

        public void TickFixed(float jumpForce)
        {
            if (_rigidboyd.velocity.y != 0) return;

            _rigidboyd.velocity = Vector3.zero;
            _rigidboyd.AddForce(Vector3.up * Time.deltaTime * jumpForce);

        }
    }
}