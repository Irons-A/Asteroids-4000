using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Configuration
{
    [System.Serializable]
    public class PlayerConfig
    {
        public float AccelerationSpeed = 5f;
        public float DecelerationSpeed = 2f;
        public float TopSpeed = 10f;
        public float RotationSpeed = 180f;
        public int InitialLives = 3;
        public float BulletFireRate = 0.2f;
        public float LaserCooldown = 2f;
        public float LaserDuration = 0.5f;
    }
}
