﻿namespace Platformer
{
    using System.Collections.Generic;
    public class UpdateControllerModel
    {
        private readonly List<IUpdateble> _updateControllers;
        private readonly List<ILateUpdateble> _lateUpdateControllers;
        private readonly List<IFixedUpdateble> _fixedUpdateControllers;
        public UpdateControllerModel()
        {
            _updateControllers = new List<IUpdateble>(8);
            _lateUpdateControllers = new List<ILateUpdateble>(8);
            _fixedUpdateControllers = new List<IFixedUpdateble>(8);
        }

        public List<IUpdateble> UpdateControllers => _updateControllers;

        public List<IFixedUpdateble> FixedUpdateControllers => _fixedUpdateControllers;

        public List<ILateUpdateble> LateUpdateControllers => _lateUpdateControllers;
    }
}