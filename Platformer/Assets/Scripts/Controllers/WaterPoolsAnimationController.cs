using System.Collections.Generic;

namespace Platformer
{
    public class WaterPoolsAnimationController: IUpdateble
    {
        private SpriteAnimatorController _waterAnimatorController;
        private List<WaterPoolObject> _waterPoolObjectViews = new List<WaterPoolObject>();

        private const AnimState WATER_STATE = AnimState.Idle;

        public WaterPoolsAnimationController(WaterObjectsInitModel waterInitModel)
        {
            _waterPoolObjectViews = waterInitModel.WaterPoolObjectViews;
            _waterAnimatorController = new SpriteAnimatorController(waterInitModel.WaterSpriteAnimatorConfig);

            for (int i = 0; i < _waterPoolObjectViews.Count; i++)
            {
                for (int j = 0; j < _waterPoolObjectViews[i].WaterSpriteRenderers.Count; j++)
                {
                    _waterAnimatorController.StartAnimation(_waterPoolObjectViews[i].WaterSpriteRenderers[j], WATER_STATE, true, j);
                }
            }
        }

        public void Update(float deltaTime)
        {
            _waterAnimatorController.Update(deltaTime);
        }
    }
}