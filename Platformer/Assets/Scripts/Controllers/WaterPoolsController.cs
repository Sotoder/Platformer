using System.Collections.Generic;

namespace Platformer
{
    public class WaterPoolsController: IUpdateble
    {
        private SpriteAnimatorController _waterAnimatorController;
        private List<WaterPoolObjectView> _waterPoolObjectViews = new List<WaterPoolObjectView>();

        private const AnimState WATER_STATE = AnimState.Idle;

        public WaterPoolsController(WaterObjectsInitModel waterInitModel)
        {
            _waterPoolObjectViews = waterInitModel.WaterPoolObjectViews;
            _waterAnimatorController = new SpriteAnimatorController(waterInitModel.WaterSpriteAnimatorConfig);

            for (int i = 0; i < _waterPoolObjectViews.Count; i++)
            {
                for (int j = 0; j < _waterPoolObjectViews[i].WaterSpriteRenderers.Count; j++)
                {
                    _waterAnimatorController.StartAnimation(_waterPoolObjectViews[i].WaterSpriteRenderers[j], WATER_STATE, true, 15, j);
                }
            }
        }

        public void Update(float deltaTime)
        {
            _waterAnimatorController.Update(deltaTime);
        }
    }
}