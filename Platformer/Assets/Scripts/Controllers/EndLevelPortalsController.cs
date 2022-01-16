namespace Platformer
{
    public class EndLevelPortalsController: IUpdateble
    {
        private EndLevelPortalsControllerModel _endLevelPortalsModel;
        private SpriteAnimatorController _spriteAnimatorController;

        public EndLevelPortalView EndLevelPortal => _endLevelPortalsModel.CurrentEndLevelPortal;

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
    }
}