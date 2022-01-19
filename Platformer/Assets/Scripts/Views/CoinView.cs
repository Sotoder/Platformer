using UnityEngine;

namespace Platformer
{
    public class CoinView: ITriggerObject
    {
        private GameObject _coinObject;
        private SpriteRenderer _coinSpriteRenderer;
        private int _instanceID;
        private Transform _coinTransform;
        
        public bool IsOnScene;

        public GameObject CoinObject { get => _coinObject; }
        public SpriteRenderer CoinSpriteRenderer { get => _coinSpriteRenderer; }
        public int InstanceID { get => _instanceID; }
        public Transform Transform { get => _coinTransform; }

        public CoinView(GameObject coinObject)
        {
            _coinObject = coinObject;
            _coinSpriteRenderer = _coinObject.GetComponent<SpriteRenderer>();
            _instanceID = _coinObject.GetInstanceID();
            _coinTransform = _coinObject.transform;
        }
    }
}