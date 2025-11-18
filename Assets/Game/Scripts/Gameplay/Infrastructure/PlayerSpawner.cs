using Player.View;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay.Infrastructure
{
    public class PlayerSpawner : IInitializable
    {
        private readonly DiContainer _container;
        private readonly PlayerFacade _playerFacade;
        private readonly GameObject _playerPrefab;
        private readonly Transform _spawnPoint;

        public PlayerSpawner(
            DiContainer container,
            PlayerFacade playerFacade,
            GameObject playerPrefab,
            Transform spawnPoint)
        {
            _container = container;
            _playerFacade = playerFacade;
            _playerPrefab = playerPrefab;
            _spawnPoint = spawnPoint;
        }

        public void Initialize()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            if (_playerPrefab == null)
            {
                Debug.LogError("Player prefab is not assigned!");
                return;
            }

            GameObject playerInstance = _container.InstantiatePrefab(
                _playerPrefab,
                _spawnPoint?.position ?? Vector3.zero,
                Quaternion.identity,
                null
            );

            PlayerView playerView = playerInstance.GetComponent<PlayerView>();
            if (playerView != null)
            {
                playerView.Construct(_playerFacade);
            }
            else
            {
                Debug.LogError("PlayerView component not found on player prefab!");
            }
        }
    }
}
