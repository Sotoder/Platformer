using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameInitModel _gameInitModel;

        private MainUpdateController _updateController;

        void Awake()
        {
            _updateController = new MainUpdateController();
            new MainInitializator(_updateController, _gameInitModel);
        }

        void Update()
        {
            _updateController.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _updateController.LateUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _updateController.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}
