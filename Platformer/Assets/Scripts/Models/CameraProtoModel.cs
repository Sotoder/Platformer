﻿using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class CameraProtoModel
    {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private CameraConfig _cameraConfig;

        public Transform CameraTransform { get => _cameraTransform; }
        public CameraConfig CameraConfig { get => _cameraConfig; }
    }
}