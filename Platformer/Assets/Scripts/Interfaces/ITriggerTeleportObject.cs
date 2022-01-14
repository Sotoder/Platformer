using UnityEngine;

namespace Platformer
{
    public interface ITriggerTeleportObject: ITriggerObject
    {
        public Vector2 PairObjectPosition { get; }
        public int TeleportationOffset { get; }
    }
}