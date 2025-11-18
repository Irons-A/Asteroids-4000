using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UserInput
{
    public class InputStrategyFactory
    {
        private readonly InputConfig _config;

        public InputStrategyFactory(InputConfig config)
        {
            _config = config;
        }

        public IInputStrategy CreateKeyboardMouseStrategy()
        {
            return new KeyboardMouseInputStrategy(_config);
        }

        public IInputStrategy CreateGamepadStrategy()
        {
            return new GamepadInputStrategy(_config);
        }

        public IInputStrategy CreateMobileStrategy()
        {
            // For now, return keyboard as fallback
            return new KeyboardMouseInputStrategy(_config);
        }
    }
}
