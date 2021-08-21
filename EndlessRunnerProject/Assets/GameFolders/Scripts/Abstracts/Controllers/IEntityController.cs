using UnityEngine;

namespace EndlessRunnerProject.Abstacts.Controllers
{
    public interface IEntityController
    {
        Transform transform { get; }
        float MoveSpeed { get; }
        float MoveBoundary { get; }

    }
}