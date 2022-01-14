using UnityEngine;

namespace Platformer
{
    public class TeleportView: ITriggerTeleportObject
    {
        private GameObject _teleprtObject;
        private Vector2 _pairObjectPosition;
        private SpriteRenderer _spriteRenderer;
        private int _instanceID;
        private int _teleportationOffset;

        public GameObject TeleprtObject { get => _teleprtObject; }
        public Vector2 PairObjectPosition { get => _pairObjectPosition; }
        public int InstanceID { get => _instanceID; }
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer; }
        public int TeleportationOffset { get => _teleportationOffset; }

        public TeleportView(GameObject teleportObject, GameObject pairObject, SpriteRenderer teleportSpriteRenderer, int teleportationOffset)
        {
            _teleprtObject = teleportObject;
            _pairObjectPosition = pairObject.transform.position;
            _spriteRenderer = teleportSpriteRenderer;
            _instanceID = _teleprtObject.GetInstanceID();
            _teleportationOffset = teleportationOffset * (pairObject.transform.lossyScale.x > 0? 1: -1);
        }
    }
}