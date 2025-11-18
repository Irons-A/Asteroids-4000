using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.UserInput
{
    public class InputDetector : ITickable
    {
        private IInputStrategy _currentStrategy;
        private readonly InputStrategyFactory _strategyFactory;
        private InputDeviceType _currentDevice;

        public Vector2 MovementInput => _currentStrategy.GetMovementInput();
        public Vector2 RotationInput => _currentStrategy.GetRotationInput();
        public bool IsAccelerating => _currentStrategy.IsAccelerating();
        public bool IsDecelerating => _currentStrategy.IsDecelerating();
        public bool IsShootingBullet => _currentStrategy.IsShootingBullet();
        public bool IsShootingLaser => _currentStrategy.IsShootingLaser();
        public bool IsPausePressed => _currentStrategy.IsPausePressed();

        public InputDetector(InputStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
            _currentStrategy = _strategyFactory.CreateKeyboardMouseStrategy();
            _currentDevice = InputDeviceType.KeyboardMouse;
        }

        public void Tick()
        {
            DetectInputDevice();
            _currentStrategy.Update();
        }

        public bool IsUsingMouse()
        {
            return _currentDevice == InputDeviceType.KeyboardMouse;
        }

        private void DetectInputDevice()
        {
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f ||
                Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f ||
                Input.GetKeyDown(KeyCode.JoystickButton0) ||
                Mathf.Abs(Input.GetAxis("RightStickHorizontal")) > 0.1f ||
                Mathf.Abs(Input.GetAxis("RightStickVertical")) > 0.1f)
            {
                if (_currentDevice != InputDeviceType.Gamepad)
                {
                    _currentStrategy = _strategyFactory.CreateGamepadStrategy();
                    _currentDevice = InputDeviceType.Gamepad;
                }
                return;
            }

            if (Input.anyKey || Input.mousePosition != Vector3.zero)
            {
                if (_currentDevice != InputDeviceType.KeyboardMouse)
                {
                    _currentStrategy = _strategyFactory.CreateKeyboardMouseStrategy();
                    _currentDevice = InputDeviceType.KeyboardMouse;
                }
            }
        }
    }
}
