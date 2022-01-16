using UnityEngine;

namespace Platformer
{
    public class CoinsSpawnController
    {
        private CoinsPool _coinsPool;
        private CoinsSpawnPoints _spawntPoints;
        private Transform _cameraTransform;
        private PlayerView _playerView;

        public CoinsSpawnController(CoinsPool coinsPool, CoinsSpawnPoints coinsSpawnPoints, Transform cameraTransform, PlayerView playerView)
        {
            _coinsPool = coinsPool;
            _spawntPoints = coinsSpawnPoints;
            _cameraTransform = cameraTransform;
            _playerView = playerView;

            _playerView.FoundTriggerObject += CheckTriggeredCoin;
        }

        private void CheckTriggeredCoin(Collider2D collider)
        {
            for (int i = 0; i < _spawntPoints.SpawnPointsList.Count; i++)
            {
                if (_spawntPoints.SpawnPointsList[i].Coin != null && collider.gameObject.GetInstanceID() == _spawntPoints.SpawnPointsList[i].Coin.InstanceID)
                {
                    _spawntPoints.SpawnPointsList[i].IsCollected = true;
                    _coinsPool.Return(_spawntPoints.SpawnPointsList[i].Coin);
                    _spawntPoints.SpawnPointsList[i].Coin = null;
                    break;
                }
            }
        }

        public void Update()
        {
            if (Time.frameCount % 2 == 0) // уменьшаем количество выполняемых проверок
            {
                SpawnAndDespawnCoinsRelativePlayerCamera();
            }
        }

        private void SpawnAndDespawnCoinsRelativePlayerCamera()
        {
            for (int i = 0; i < _spawntPoints.SpawnPointsList.Count; i++)
            {
                if (!_spawntPoints.SpawnPointsList[i].IsCollected) // уменьшаем количество расчетов Distance
                {
                    var distance = Vector2.Distance(_spawntPoints.SpawnPointsList[i].Transform.position, _cameraTransform.position);

                    if (distance < 12 && _spawntPoints.SpawnPointsList[i].Coin == null)
                    {
                        _spawntPoints.SpawnPointsList[i].Coin = _coinsPool.GetCoin(_spawntPoints.SpawnPointsList[i].CoinSpawnPont);
                    }
                    else if (distance >= 12 && _spawntPoints.SpawnPointsList[i].Coin != null)
                    {
                        _coinsPool.Return(_spawntPoints.SpawnPointsList[i].Coin);
                        _spawntPoints.SpawnPointsList[i].Coin = null;
                    }
                }
            }
        }
    }
}