using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UserInput
{
    [System.Serializable]
    public class InputConfig
    {
        public KeyCode AccelerateKey = KeyCode.W;
        public KeyCode DecelerateKey = KeyCode.S;
        public KeyCode ShootBulletKey = KeyCode.Space;
        public KeyCode ShootLaserKey = KeyCode.LeftShift;
        public KeyCode PauseKey = KeyCode.Escape;

        public string GamepadHorizontalAxis = "Horizontal";
        public string GamepadVerticalAxis = "Vertical";
        public string GamepadRightStickHorizontal = "RightStickHorizontal";
        public string GamepadRightStickVertical = "RightStickVertical";
        public KeyCode GamepadShootBullet = KeyCode.JoystickButton0;
        public KeyCode GamepadShootLaser = KeyCode.JoystickButton1;
        public KeyCode GamepadPause = KeyCode.JoystickButton7;

        public float GamepadDeadzone = 0.2f;
        public float MouseRotationSensitivity = 1f;
    }
}
