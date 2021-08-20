using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Abstacts.Inputs
{
    public interface IInputReader
    {
        float Horizontal { get; }
         bool IsJump { get; }
    }
}