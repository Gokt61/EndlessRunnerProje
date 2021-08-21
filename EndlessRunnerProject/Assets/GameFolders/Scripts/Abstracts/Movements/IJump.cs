using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Abstacts.Movements
{
    public interface IJump
    {
        void FixedTick(float _jumpForce);
    }
}