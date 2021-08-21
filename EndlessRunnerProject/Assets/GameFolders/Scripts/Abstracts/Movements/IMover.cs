using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunnerProject.Abstacts.Movements
{
    public interface IMover 
    {
        void FixedTick(float direction);
    }
}