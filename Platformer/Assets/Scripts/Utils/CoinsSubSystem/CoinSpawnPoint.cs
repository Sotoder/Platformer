using UnityEngine;

namespace Platformer
{
    public class CoinSpawnPoint
    {
        private GameObject _coinSpawnPont;
        private Transform _spawnPointTransform;

        public bool IsCollected;
        public CoinView Coin;

        public GameObject CoinSpawnPont { get => _coinSpawnPont; }
        public Transform Transform { get => _spawnPointTransform; }

        public CoinSpawnPoint(GameObject spawnPoint)
        {
            _coinSpawnPont = spawnPoint;
            _spawnPointTransform = _coinSpawnPont.transform;
        }
    }
}