using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Abstacts.Controllers
{
    public abstract class MyCharacterController : MonoBehaviour
    {
        [SerializeField] float _moveBoundary = 4.5f;
        [SerializeField] float _moveSpeed = 10;

        public float MoveSpeed => _moveSpeed;
        public float MoveBoundary => _moveBoundary;

    }
}