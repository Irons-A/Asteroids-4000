using Core.UserInput;
using Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerFacade : ITickable, IFixedTickable
    {
        private readonly PlayerMovementController _movementController;
        private readonly InputDetector _inputDetector;

        public Vector2 Position => _movementController.Position;
        public float Rotation => _movementController.Rotation;

        public PlayerFacade(PlayerMovementController movementController, InputDetector inputDetector)
        {
            _movementController = movementController;
            _inputDetector = inputDetector;
        }

        public void Tick()
        {
            HandleInput();
        }

        public void FixedTick()
        {
            _movementController.Update(Time.fixedDeltaTime);
        }

        private void HandleInput()
        {
            Vector2 rotationInput = _inputDetector.RotationInput;

            if (_inputDetector.IsUsingMouse())
            {
                _movementController.RotateTowards(rotationInput);
            }
            else
            {
                if (rotationInput != Vector2.zero)
                {
                    _movementController.RotateWithDirection(rotationInput);
                }
            }

            if (_inputDetector.IsAccelerating)
            {
                _movementController.Accelerate(Time.deltaTime);
            }
            else if (_inputDetector.IsDecelerating)
            {
                _movementController.Decelerate(Time.deltaTime);
            }
        }

        public void WarpToPosition(Vector2 newPosition)
        {
            _movementController.WarpToPosition(newPosition);
        }
    }
}
