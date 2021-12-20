using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "SpriteAnimationConfig", menuName = "Configs/Animation", order = 1)]
    public class SpriteAnimatorConfig : ScriptableObject
    {
        public float AnimationSpeed;
        public List<SpriteSequence> SpriteSequences = new List<SpriteSequence>();
    }
}