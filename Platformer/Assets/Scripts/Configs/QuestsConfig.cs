using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    [CreateAssetMenu(fileName = "QuestsConfig", menuName = "Configs/QuestsList", order = 2)]
    public class QuestsConfig : ScriptableObject
    {
        [SerializeField] private List<CollectableQuestConfig> _collectableQuestConfigs;

        public List<CollectableQuestConfig> CollectableQuestConfigs { get => _collectableQuestConfigs; }
    }
}
