using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class FlyEnemyInitModel: IEnemyInitModel
    {
        [SerializeField] private GameObject _spawnPoint;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private FlyEnemyModelConfig _flyEnemyConfig;

        public GameObject SpawnPoint { get => _spawnPoint; }
        public GameObject Prefab { get => _prefab; }
        public FlyEnemyModelConfig FlyEnemyConfig { get => _flyEnemyConfig; }
    }
}