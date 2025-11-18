using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UserInput
{
    public class KeyboardMouseInputStrategy : IInputStrategy
    {
        private readonly InputConfig _config;

        public KeyboardMouseInputStrategy(InputConfig config)
        {
            _config = config;
        }

        public Vector2 GetMovementInput()
        {
            return Vector2.zero;
        }

        public Vector2 GetRotationInput()
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return new Vector2(mouseWorldPos.x, mouseWorldPos.y);
        }

        public bool IsAccelerating()
        {
            return Input.GetKey(_config.AccelerateKey);
        }

        public bool IsDecelerating()
        {
            return Input.GetKey(_config.DecelerateKey);
        }

        public bool IsShootingBullet()
        {
            return Input.GetKeyDown(_config.ShootBulletKey);
        }

        public bool IsShootingLaser()
        {
            return Input.GetKeyDown(_config.ShootLaserKey);
        }

        public bool IsPausePressed()
        {
            return Input.GetKeyDown(_config.PauseKey);
        }

        public void Update()
        {
        }
    }
}
