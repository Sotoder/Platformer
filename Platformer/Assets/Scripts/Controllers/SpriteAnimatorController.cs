using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class SpriteAnimatorController : IDisposable
    {
        private SpriteAnimatorConfig _animatorConfig;
        private Dictionary<SpriteRenderer, Animation> _activeAnimation = new Dictionary<SpriteRenderer, Animation>();

        public Dictionary<SpriteRenderer, Animation> ActiveAnimation { get => _activeAnimation; }
        public SpriteAnimatorConfig AnimatorConfig { get => _animatorConfig; }

        public SpriteAnimatorController(SpriteAnimatorConfig config)
        {
            _animatorConfig = config;
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, AnimState track, bool loop)
        {
            if(_activeAnimation.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = _animatorConfig.AnimationSpeed;
                animation.Sleep = false;
                
                if(animation.Track != track)
                {
                    animation.Track = track;
                    animation.Sprites = _animatorConfig.SpriteSequences.Find(sequence => sequence.Track == track).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _activeAnimation.Add(spriteRenderer, new Animation()
                {
                    Track = track,
                    Sprites = _animatorConfig.SpriteSequences.Find(sequence => sequence.Track == track).Sprites,
                    Loop = loop,
                    Speed = _animatorConfig.AnimationSpeed,
                    Sleep = false
                });
            }
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, AnimState track, bool loop, int startPosition)
        {
            if (_activeAnimation.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = _animatorConfig.AnimationSpeed;
                animation.Sleep = false;
                animation.Counter = startPosition;

                if (animation.Track != track)
                {
                    animation.Track = track;
                    animation.Sprites = _animatorConfig.SpriteSequences.Find(sequence => sequence.Track == track).Sprites;
                    animation.Counter = startPosition;
                }
            }
            else
            {
                _activeAnimation.Add(spriteRenderer, new Animation()
                {
                    Track = track,
                    Sprites = _animatorConfig.SpriteSequences.Find(sequence => sequence.Track == track).Sprites,
                    Loop = loop,
                    Speed = _animatorConfig.AnimationSpeed,
                    Sleep = false,
                    Counter = startPosition
                });
            }
        }

        public void StopAnimation(SpriteRenderer spriteRenderer)
        {
            if (_activeAnimation.ContainsKey(spriteRenderer))
            {
                _activeAnimation.Remove(spriteRenderer);
            }
        }

        public void Update(float deltaTime)
        {
            foreach (var animation in _activeAnimation)
            {
                if (animation.Key.isVisible)
                {
                    animation.Value.Update(deltaTime);
                    if (animation.Value.Counter < animation.Value.Sprites.Count)
                    {
                        animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
                    }
                }
            }
        }

        public void Dispose()
        {
            _activeAnimation.Clear();
        }
    }
}
