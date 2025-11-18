using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.Bootstrap
{
    public class GameBootstrap : IInitializable
    {
        public void Initialize()
        {
            Debug.Log("Game bootstrap completed!");
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
        }
    }
}
