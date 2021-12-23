using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CoinsSubsystemController: IUpdateble
    {
        private CoinsPool _coinsPool;
        private CoinsSpawnPoints _spawnPoints;
        private CoinsAnimationController _coinsAnimationController;
        private CoinsAdapter _coinsAdapter;
        private CoinsSpawnController _coinsSpawnController;

        public List<SpriteRenderer> CoinsSpriteRenderers => _coinsAdapter.CoinsSpriteRenderers;
        public List<ITriggerObject> TriggeredObjects => _coinsAdapter.CoinsObjects;

        public CoinsSubsystemController(CoinsProtoModel coinsProtoModel, Transform cameraTransform, PlayerView playerView)
        {
            _coinsPool = new CoinsPool(coinsProtoModel.CoinPoolRootTransform, coinsProtoModel.CoinsPoolCapacity, coinsProtoModel.CoinPrefab);            
            _spawnPoints = new CoinsSpawnPoints(coinsProtoModel.CoinsSpawnPoint);

            _coinsAdapter = new CoinsAdapter(_coinsPool.Coins);

            _coinsAnimationController = new CoinsAnimationController(coinsProtoModel.SpriteAnimatorConfig, CoinsSpriteRenderers);

            _coinsSpawnController = new CoinsSpawnController(_coinsPool, _spawnPoints, cameraTransform, playerView);
        }

        public void Update(float deltaTime)
        {
            _coinsAnimationController.Update(deltaTime);
            _coinsSpawnController.Update();
        }
    }
}