using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player.View
{
    public class PlayerView : MonoBehaviour
    {
        private Player.PlayerFacade _playerFacade;

        public void Construct(Player.PlayerFacade playerFacade)
        {
            _playerFacade = playerFacade;
        }

        private void Update()
        {
            if (_playerFacade == null) return;

            transform.position = new Vector3(_playerFacade.Position.x, _playerFacade.Position.y, 0);
            transform.rotation = Quaternion.Euler(0, 0, _playerFacade.Rotation);
        }

        public void WarpToPosition(Vector2 newPosition)
        {
            _playerFacade?.WarpToPosition(newPosition);
        }
    }
}
