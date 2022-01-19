using System;
using UnityEngine;

namespace Platformer
{
    public class EndLevelPortalsController: IUpdateble
    {
        private EndLevelPortalsControllerModel _endLevelPortalsModel;
        private SpriteAnimatorController _spriteAnimatorController;
        private QuestsController _questsController;

        public EndLevelPortalView CurentEndLevelPortal => _endLevelPortalsModel.CurrentEndLevelPortal;

        public EndLevelPortalsController(EndLevelPortalsProtoModel endLevelPortalsProtoModel)
        {
            _endLevelPortalsModel = new EndLevelPortalsControllerModel(endLevelPortalsProtoModel);
            _spriteAnimatorController = new SpriteAnimatorController(endLevelPortalsProtoModel.SpriteAnimatorConfig);

            _spriteAnimatorController.StartAnimation(_endLevelPortalsModel.CurrentEndLevelPortal.EndLevelPortalSpriteRenderer, AnimState.Idle, true);
        }

        public void Update(float deltaTime)
        {
            _spriteAnimatorController.Update(deltaTime);
        }

        public void ChangeLevel(Levels level)
        {
            foreach (var endLevelPortalView in _endLevelPortalsModel.EndLevelPortalViews)
            {
                if(endLevelPortalView.NextLevelType == level)
                {
                    _spriteAnimatorController.StopAnimation(_endLevelPortalsModel.CurrentEndLevelPortal.EndLevelPortalSpriteRenderer);
                    _endLevelPortalsModel.CurrentEndLevelPortal = endLevelPortalView.SetInstanceID();
                    _spriteAnimatorController.StartAnimation(_endLevelPortalsModel.CurrentEndLevelPortal.EndLevelPortalSpriteRenderer, AnimState.Idle, true);
                }
            }
        }

        public void SubscribeOnQuests(QuestsController questsController)
        {
            _questsController = questsController;
            _questsController.QuestComplite += CheckComplitedQuest;
        }

        private void CheckComplitedQuest(int questID)
        {
            if(questID == 2213 && CurentEndLevelPortal.CurentLevelType == Levels.PlatformValley)
            {
                ActivateCurentLevelPortal();
            }
        }

        private void ActivateCurentLevelPortal()
        {
            CurentEndLevelPortal.IsActive = true;
            CurentEndLevelPortal.EndLevelPortalSpriteRenderer.color = Color.white;
        }
    }
}