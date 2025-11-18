using Player;
using Player.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay.Infrastructure
{
    public class PlayerViewInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Transform playerSpawnPoint;

        public override void InstallBindings()
        {
            // We'll spawn the player when we have all dependencies ready
            Container.BindInterfacesTo<PlayerSpawnHandler>().AsSingle().NonLazy();
        }

        private class PlayerSpawnHandler : IInitializable
        {
            private readonly DiContainer _container;
            private readonly GameObject _playerPrefab;
            private readonly Transform _spawnPoint;
            private readonly PlayerFacade _playerFacade;

            public PlayerSpawnHandler(
                DiContainer container,
                PlayerFacade playerFacade,
                [Inject(Optional = true)] GameObject playerPrefab = null,
                [Inject(Optional = true)] Transform spawnPoint = null)
            {
                _container = container;
                _playerFacade = playerFacade;
                _playerPrefab = playerPrefab;
                _spawnPoint = spawnPoint;
            }

            public void Initialize()
            {
                if (_playerPrefab == null)
                {
                    Debug.LogError("Player prefab is not assigned in PlayerViewInstaller!");
                    return;
                }

                Vector3 spawnPosition = _spawnPoint != null ? _spawnPoint.position : Vector3.zero;

                GameObject playerInstance = _container.InstantiatePrefab(
                    _playerPrefab,
                    spawnPosition,
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
}
