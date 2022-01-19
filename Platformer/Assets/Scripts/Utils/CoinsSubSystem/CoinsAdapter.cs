using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CoinsAdapter
    {
        private List<SpriteRenderer> _coinsSpriteRenderers = new List<SpriteRenderer>();
        private List<ITriggerObject> _coinsObjects = new List<ITriggerObject>();
        public List<SpriteRenderer> CoinsSpriteRenderers { get => _coinsSpriteRenderers; }
        public List<ITriggerObject> CoinsObjects { get => _coinsObjects; }

        public CoinsAdapter(List<CoinView> coins)
        {
            for (int i = 0; i < coins.Count; i++)
            {
                _coinsSpriteRenderers.Add(coins[i].CoinSpriteRenderer);
                _coinsObjects.Add(coins[i]);
            }
        }
    }
}