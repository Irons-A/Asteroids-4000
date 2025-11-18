using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UserInput
{
    public interface IInputStrategy
    {
        Vector2 GetMovementInput();
        Vector2 GetRotationInput();
        bool IsAccelerating();
        bool IsDecelerating();
        bool IsShootingBullet();
        bool IsShootingLaser();
        bool IsPausePressed();
        void Update();
    }
}
