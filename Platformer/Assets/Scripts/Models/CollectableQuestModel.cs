namespace Platformer
{
    public class CollectableQuestModel
    {
        private QuestTypes _questType;
        private string _questName;
        private int _questID;
        private int _countItemsToCollect;
        private string _questText;

        public int CountItemsToCollect { get => _countItemsToCollect; }
        public string QuestName { get => _questName; }
        public int QuestID { get => _questID; }
        public string QuestText { get => _questText; }
        public QuestTypes QuestType { get => _questType; }

        public CollectableQuestModel(CollectableQuestConfig config)
        {
            _questType = config.QuestType;
            _questName = config.QuestName;
            _questID = config.QuestID;
            _countItemsToCollect = config.CountItemsToCollect;
            _questText = config.QuestText;
        }
    }
}