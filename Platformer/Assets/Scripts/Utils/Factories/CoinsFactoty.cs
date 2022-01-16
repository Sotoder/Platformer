using UnityEngine;

namespace Platformer
{
    internal class CoinsFactoty
    {
        private GameObject _coinPrefab;

        public CoinsFactoty(GameObject coinPrefab)
        {
            _coinPrefab = coinPrefab;
        }

        public GameObject Create(Transform rootTransform)
        {
            var coin = Object.Instantiate(_coinPrefab);
            coin.transform.position = rootTransform.position;
            coin.transform.parent = rootTransform;
            coin.SetActive(false);

            return coin;
        }
    }
}