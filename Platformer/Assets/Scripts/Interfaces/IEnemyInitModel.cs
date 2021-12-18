using UnityEngine;

namespace Platformer
{
    public interface IEnemyInitModel
    {
        public GameObject SpawnPoint { get; }
        public GameObject Prefab { get; }
        public FlyEnemyModelConfig FlyEnemyConfig { get; }
    }
}