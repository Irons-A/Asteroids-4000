using Core.Physics;
using Player.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Movement
{
    public class PlayerMovementController
    {
        private readonly PhysicsBody _physicsBody;
        private readonly PlayerConfig _config;

        public PhysicsBody PhysicsBody => _physicsBody;
        public Vector2 Position => _physicsBody.Position;
        public float Rotation => _physicsBody.Rotation;

        public PlayerMovementController(PlayerConfig config, Vector2 initialPosition)
        {
            _config = config;
            _physicsBody = new PhysicsBody(initialPosition);
        }

        public void Accelerate(float deltaTime)
        {
            Vector2 accelerationDirection = GetForwardDirection();
            Vector2 acceleration = accelerationDirection * _config.AccelerationSpeed * deltaTime;

            _physicsBody.ApplyAcceleration(acceleration);

            if (_physicsBody.Velocity.magnitude > _config.TopSpeed)
            {
                _physicsBody.SetVelocity(_physicsBody.Velocity.normalized * _config.TopSpeed);
            }
        }

        public void Decelerate(float deltaTime)
        {
            _physicsBody.ApplyFriction(_config.DecelerationSpeed * deltaTime);
        }

        public void RotateTowards(Vector2 targetWorldPosition)
        {
            Vector2 directionToTarget = targetWorldPosition - _physicsBody.Position;
            if (directionToTarget == Vector2.zero) return;

            float targetAngle = Mathf.Atan2(directionToTarget.x, directionToTarget.y) * Mathf.Rad2Deg;
            _physicsBody.SetRotation(targetAngle);
        }

        public void RotateWithDirection(Vector2 direction)
        {
            if (direction == Vector2.zero) return;

            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            _physicsBody.SetRotation(targetAngle);
        }

        public void Update(float deltaTime)
        {
            _physicsBody.Update(deltaTime);
        }

        private Vector2 GetForwardDirection()
        {
            float angleInRadians = _physicsBody.Rotation * Mathf.Deg2Rad;
            return new Vector2(Mathf.Sin(angleInRadians), Mathf.Cos(angleInRadians));
        }

        public void WarpToPosition(Vector2 newPosition)
        {
            _physicsBody.SetPosition(newPosition);
        }
    }
}
