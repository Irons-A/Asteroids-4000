using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay.Environment
{
    public class ScreenWrapper : ITickable
    {
        private readonly Camera _mainCamera;
        private readonly PlayerFacade _playerFacade;

        public ScreenWrapper(PlayerFacade playerFacade)
        {
            _playerFacade = playerFacade;
            _mainCamera = Camera.main;
        }

        public void Tick()
        {
            WrapPlayerIfNeeded();
        }

        private void WrapPlayerIfNeeded()
        {
            if (_mainCamera == null) return;

            Vector3 playerWorldPos = new Vector3(_playerFacade.Position.x, _playerFacade.Position.y, 0);
            Vector2 viewportPosition = _mainCamera.WorldToViewportPoint(playerWorldPos);

            bool needsWrapping = false;
            Vector2 newPosition = _playerFacade.Position;

            if (viewportPosition.x > 1.0f)
            {
                newPosition.x = GetOppositeWorldPosition(0f, viewportPosition.y).x;
                needsWrapping = true;
            }
            else if (viewportPosition.x < 0.0f)
            {
                newPosition.x = GetOppositeWorldPosition(1f, viewportPosition.y).x;
                needsWrapping = true;
            }

            if (viewportPosition.y > 1.0f)
            {
                newPosition.y = GetOppositeWorldPosition(viewportPosition.x, 0f).y;
                needsWrapping = true;
            }
            else if (viewportPosition.y < 0.0f)
            {
                newPosition.y = GetOppositeWorldPosition(viewportPosition.x, 1f).y;
                needsWrapping = true;
            }

            if (needsWrapping)
            {
                _playerFacade.WarpToPosition(newPosition);
            }
        }

        private Vector2 GetOppositeWorldPosition(float viewportX, float viewportY)
        {
            Vector3 worldPosition = _mainCamera.ViewportToWorldPoint(new Vector3(viewportX, viewportY, 0));
            return new Vector2(worldPosition.x, worldPosition.y);
        }
    }
}
