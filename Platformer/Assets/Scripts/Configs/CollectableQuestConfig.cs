using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    [CreateAssetMenu(fileName = "CollectableQuestConfig", menuName = "Configs/QuestTypes/Collectable", order = 1)]
    public class CollectableQuestConfig : ScriptableObject
    {
        private QuestTypes _questType = QuestTypes.Collectable;

        [SerializeField] private string _questName;
        [SerializeField] private int _questID;
        [SerializeField] private CollectableItems _collectableItems;
        [SerializeField] [Range(1, 10)] private int _countItemsToCollect;
        [SerializeField] [TextArea] private string _questText;

        public QuestTypes QuestType { get => _questType; }
        public CollectableItems CollectableItems { get => _collectableItems; }
        public int CountItemsToCollect { get => _countItemsToCollect; }
        public string QuestName { get => _questName; }
        public int QuestID { get => _questID; }
        public string QuestText { get => _questText; }
    }
}