using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Configs/Camera", order = 5)]
    public class CameraConfig: ScriptableObject
    {
        [SerializeField] List<CameraLevelSettings> _cameraLevelSettings;

        public List<CameraLevelSettings> CameraLevelSettings { get => _cameraLevelSettings; }
    }
}