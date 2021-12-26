using UnityEngine;

namespace Platformer
{
    public interface ITriggerEndLevelPortalObject: ITriggerObject
    {
        public Vector2 NextLevelStartPosition { get; }
        public Levels NextLevelType { get; }
    }
}