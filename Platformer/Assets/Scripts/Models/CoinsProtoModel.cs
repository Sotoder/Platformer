using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class CoinsProtoModel
    {
        [SerializeField] private SpriteAnimatorConfig _spriteAnimatorConfig;
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private Transform _coinPoolRootTransform;
        [SerializeField] private int _coinsPoolCapacity;
        [SerializeField] private List<GameObject> _coinsSpawnPoint;

        public SpriteAnimatorConfig SpriteAnimatorConfig { get => _spriteAnimatorConfig; }
        public GameObject CoinPrefab { get => _coinPrefab; }
        public List<GameObject> CoinsSpawnPoint { get => _coinsSpawnPoint; }
        public Transform CoinPoolRootTransform { get => _coinPoolRootTransform; }
        public int CoinsPoolCapacity { get => _coinsPoolCapacity; }
    }
}