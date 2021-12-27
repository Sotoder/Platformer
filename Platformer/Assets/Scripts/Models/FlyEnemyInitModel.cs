using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class FlyEnemyInitModel: IEnemyInitModel
    {
        [SerializeField] private GameObject _spawnPoint;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private AgroZone _agroZone;
        [SerializeField] private FlyEnemyModelConfig _flyEnemyConfig;

        public GameObject SpawnPoint { get => _spawnPoint; }
        public GameObject Prefab { get => _prefab; }
        public FlyEnemyModelConfig FlyEnemyConfig { get => _flyEnemyConfig; }
        public AgroZone AgroZone { get => _agroZone; }
    }
}