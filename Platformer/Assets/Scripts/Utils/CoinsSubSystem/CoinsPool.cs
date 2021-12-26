using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CoinsPool
    {
        private Transform _coinPoolRootTransform;
        private GameObject _coinPrefab;
        private CoinsFactoty _coinsFactory;

        private List<CoinView> _coins;

        public List<CoinView> Coins { get => _coins; }

        public CoinsPool(Transform coinPoolRootTransform, int coinsPoolCapacity, GameObject coinPrefab)
        {
            _coinPoolRootTransform = coinPoolRootTransform;
            _coinPrefab = coinPrefab;

            _coins = new List<CoinView>(coinsPoolCapacity);
            _coinsFactory = new CoinsFactoty(_coinPrefab);

            FillPool(coinsPoolCapacity);
        }

        private void FillPool(int poolCapacity)
        {
            for (int i = 0; i < poolCapacity; i++)
            {
                _coins.Add(new CoinView(_coinsFactory.Create(_coinPoolRootTransform)));
            }
        }

        public CoinView GetCoin(GameObject coinSpawnPont)
        {
            CoinView coin = null;

            foreach (var element in _coins)
            {
                if (!element.IsOnScene)
                {
                    coin = element;
                    break;
                }
            }

            if (coin is null)
            {
                coin = new CoinView(_coinsFactory.Create(_coinPoolRootTransform));
                _coins.Add(coin);
            }

            coin.CoinObject.SetActive(true);
            coin.IsOnScene = true;
            coin.Transform.position = coinSpawnPont.transform.position;
            return coin;
        }

        public void Return(CoinView coin)
        {
            coin.CoinObject.SetActive(false);
            coin.Transform.position = _coinPoolRootTransform.position;
            coin.IsOnScene = false;
        }
    }
}