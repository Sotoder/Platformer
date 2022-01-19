using System;

namespace Platformer
{
    public class CollectableQuest : Quest
    {
        public Action<int, QuestTypes> QuestComplite = delegate (int i, QuestTypes questType) { };

        private IPlayerDataForQuests _playerDataForQuests;
        private CollectableQuestModel _questModel;

        public CollectableQuestModel QuestModel { get => _questModel; }

        public CollectableQuest(CollectableQuestConfig config, IPlayerDataForQuests data)
        {
            _playerDataForQuests = data;

            _questModel = new CollectableQuestModel(config);
        }

        public override void Complite()
        {
            QuestComplite.Invoke(_questModel.QuestID, _questModel.QuestType);
        }

        public override void Update()
        {
            if(_playerDataForQuests.CoinsScore >= _questModel.CountItemsToCollect)
            {
                Complite();
            }
        }
    }
}