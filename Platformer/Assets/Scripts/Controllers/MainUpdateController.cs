
namespace Platformer
{
    public class MainUpdateController : IController
    {
        private UpdateControllerModel _model;

        public MainUpdateController()
        {
            _model = new UpdateControllerModel();
        }

        public void Add(IController controller)
        {
            if (controller is IUpdateble updateController)
            {
                _model.UpdateControllers.Add(updateController);
            }

            if (controller is IFixedUpdateble fixedUpdateController)
            {
                _model.FixedUpdateControllers.Add(fixedUpdateController);
            }
        }

        public void Update(float deltaTime)
        {
            for (var element = 0; element < _model.UpdateControllers.Count; ++element)
            {
                _model.UpdateControllers[element].Update(deltaTime);
            }
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            for (var element = 0; element < _model.FixedUpdateControllers.Count; ++element)
            {
                _model.FixedUpdateControllers[element].FixedUpdate(fixedDeltaTime);
            }
        }
    }
}