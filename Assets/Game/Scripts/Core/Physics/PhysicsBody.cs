using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Physics
{
    public class PhysicsBody
    {
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; private set; }
        public float Rotation { get; private set; }
        public float Mass { get; private set; }

        public PhysicsBody(Vector2 initialPosition, float mass = 1f)
        {
            Position = initialPosition;
            Mass = mass;
            Velocity = Vector2.zero;
            Rotation = 0f;
        }

        public void ApplyForce(Vector2 force)
        {
            if (Mass <= 0) return;
            Velocity += force / Mass;
        }

        public void ApplyAcceleration(Vector2 acceleration)
        {
            Velocity += acceleration;
        }

        public void ApplyFriction(float frictionCoefficient)
        {
            Velocity *= (1f - frictionCoefficient);
        }

        public void SetRotation(float rotation)
        {
            Rotation = rotation;
        }

        public void Update(float deltaTime)
        {
            Position += Velocity * deltaTime;
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
        }

        public void SetVelocity(Vector2 velocity)
        {
            Velocity = velocity;
        }
    }
}
