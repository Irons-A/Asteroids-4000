using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UserInput
{
    public class GamepadInputStrategy : IInputStrategy
    {
        private readonly InputConfig _config;

        public GamepadInputStrategy(InputConfig config)
        {
            _config = config;
        }

        public Vector2 GetMovementInput()
        {
            float horizontal = Input.GetAxis(_config.GamepadHorizontalAxis);
            float vertical = Input.GetAxis(_config.GamepadVerticalAxis);
            Vector2 input = new Vector2(horizontal, vertical);

            return ApplyDeadzone(input, _config.GamepadDeadzone);
        }

        public Vector2 GetRotationInput()
        {
            float horizontal = Input.GetAxis(_config.GamepadRightStickHorizontal);
            float vertical = Input.GetAxis(_config.GamepadRightStickVertical);
            Vector2 input = new Vector2(horizontal, vertical);

            return ApplyDeadzone(input, _config.GamepadDeadzone);
        }

        public bool IsAccelerating()
        {
            return GetMovementInput().y > _config.GamepadDeadzone;
        }

        public bool IsDecelerating()
        {
            return GetMovementInput().y < -_config.GamepadDeadzone;
        }

        public bool IsShootingBullet()
        {
            return Input.GetKeyDown(_config.GamepadShootBullet);
        }

        public bool IsShootingLaser()
        {
            return Input.GetKeyDown(_config.GamepadShootLaser);
        }

        public bool IsPausePressed()
        {
            return Input.GetKeyDown(_config.GamepadPause);
        }

        public void Update()
        {
        }

        private Vector2 ApplyDeadzone(Vector2 input, float deadzone)
        {
            return input.magnitude < deadzone ? Vector2.zero : input.normalized * 
                ((input.magnitude - deadzone) / (1f - deadzone));
        }
    }
}
