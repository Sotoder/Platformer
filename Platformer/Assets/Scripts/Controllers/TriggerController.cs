using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class TriggerController
    {
        public event Action GetCoin = delegate () { };

        private PlayerView _playerView;
        private Dictionary<IAnimationController, List<SpriteRenderer>> _animatedObjectsLists = new Dictionary<IAnimationController, List<SpriteRenderer>>();

        public TriggerController(PlayerView playerView)
        {
            _playerView = playerView;
            _playerView.FoundTriggerObject += CheckTriggerObject;
        }

        private void CheckTriggerObject(Collider2D collider)
        {
            foreach(var objectsList in _animatedObjectsLists)
            {
                for(int i = 0; i < objectsList.Value.Count; i++)
                {
                    if (collider.gameObject.GetInstanceID() == objectsList.Value[i].gameObject.GetInstanceID())
                    {
                        if(objectsList.Key.AnimationControllerType == typeof(CoinsAnimationController)) //Происходит ли тут каст?
                        {
                            GetCoin.Invoke();
                        }

                        objectsList.Key.RemoveSpriteRenderer(objectsList.Value[i]);
                        GameObject.Destroy(objectsList.Value[i]);
                        objectsList.Value.Remove(objectsList.Value[i]);
                        return;
                    }
                }
            }
        }

        public TriggerController AddAnimatedObjects (IAnimationController controller, List<SpriteRenderer> spriteRenderers)
        {
            _animatedObjectsLists.Add(controller, spriteRenderers);

            return this;
        }
    }
}