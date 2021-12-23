using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private PlayerInitModel _playerInitModel;

        private MainUpdateController _updateController;

        void Awake()
        {
            _updateController = new MainUpdateController();
            new MainInitializator(_updateController, _playerInitModel);
        }

        void Update()
        {
            _updateController.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _updateController.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}
