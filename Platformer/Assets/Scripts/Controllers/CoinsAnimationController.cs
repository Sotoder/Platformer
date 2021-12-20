using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CoinsAnimationController: IUpdateble, IAnimationController
    {
        public Type AnimationControllerType => this.GetType();
        
        private SpriteAnimatorController _coinAnimatorController;
        private List<SpriteRenderer> _coinsRenderer = new List<SpriteRenderer>();

        private const AnimState COUN_STATE = AnimState.Idle;

        public CoinsAnimationController(CoinsInitModel coinsInitModel)
        {
            _coinAnimatorController = new SpriteAnimatorController(coinsInitModel.SpriteAnimatorConfig);
            _coinsRenderer = coinsInitModel.CoinsRenderers;

            for (int i = 0; i < _coinsRenderer.Count; i++)
            {
                _coinAnimatorController.StartAnimation(_coinsRenderer[i], COUN_STATE, true);
            }
        }

        public void Update(float deltaTime)
        {
            _coinAnimatorController.Update(deltaTime);
        }

        public void RemoveSpriteRenderer(SpriteRenderer spriteRenderer)
        {
            _coinAnimatorController.StopAnimation(spriteRenderer);
        }
    }
}