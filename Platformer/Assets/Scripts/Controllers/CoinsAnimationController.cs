using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CoinsAnimationController
    {        
        private SpriteAnimatorController _coinAnimatorController;
        private List<SpriteRenderer> _coinsRenderers = new List<SpriteRenderer>();

        private const AnimState COUN_STATE = AnimState.Idle;

        public CoinsAnimationController(SpriteAnimatorConfig spriteAnimatorConfig, List<SpriteRenderer> coinsSpriteRenderers)
        {
            _coinAnimatorController = new SpriteAnimatorController(spriteAnimatorConfig);
            _coinsRenderers = coinsSpriteRenderers;

            for (int i = 0; i < _coinsRenderers.Count; i++)
            {
                _coinAnimatorController.StartAnimation(_coinsRenderers[i], COUN_STATE, true);
            }
        }

        public void Update(float deltaTime)
        {
            _coinAnimatorController.Update(deltaTime);
        }
    }
}