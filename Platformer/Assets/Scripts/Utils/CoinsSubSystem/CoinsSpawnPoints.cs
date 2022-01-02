using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CoinsSpawnPoints
    {
        private List<CoinSpawnPoint> _SpawnPoints = new List<CoinSpawnPoint>();
        public List<CoinSpawnPoint> SpawnPointsList { get => _SpawnPoints; }

        public CoinsSpawnPoints(List<GameObject> coinsSpawnPoint)
        {
            for (int i = 0; i < coinsSpawnPoint.Count; i++)
            {
                _SpawnPoints.Add(new CoinSpawnPoint(coinsSpawnPoint[i]));
            }
        }
    }
}