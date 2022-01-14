using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class EndLevelPortalView: ITriggerEndLevelPortalObject
    {
        [SerializeField] private GameObject _endLevelPortal;
        [SerializeField] private SpriteRenderer _endLevelPortalSpriteRenderer;
        [SerializeField] private Levels _nextLevelType;
        [SerializeField] private Transform _nextLevelStartPosition;

        private int _instanceID;

        public Levels NextLevelType { get => _nextLevelType; }
        public GameObject EndLevelPortal { get => _endLevelPortal; }
        public SpriteRenderer EndLevelPortalSpriteRenderer { get => _endLevelPortalSpriteRenderer; }
        public Vector2 NextLevelStartPosition { get => _nextLevelStartPosition.position; }
        public int InstanceID { get => _instanceID; }

        public EndLevelPortalView SetInstanceID()
        {
            _instanceID = _endLevelPortal.GetInstanceID();
            return this;
        }
    }
}