using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class TeleportsPairView
    {
        [SerializeField] private GameObject _teleportFirst;
        [SerializeField] private GameObject _teleportSecond;
        [SerializeField] private SpriteRenderer _teleportFirstSpriteRenderer;
        [SerializeField] private SpriteRenderer _teleportSecondSpriteRenderer;

        public GameObject TeleportFirst { get => _teleportFirst; }
        public GameObject TeleportSecond { get => _teleportSecond; }
        public SpriteRenderer TeleportFirstSpriteRenderer { get => _teleportFirstSpriteRenderer; }
        public SpriteRenderer TeleportSecondSpriteRenderer { get => _teleportSecondSpriteRenderer; }
    }
}