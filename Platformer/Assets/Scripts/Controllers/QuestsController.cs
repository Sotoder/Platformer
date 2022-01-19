using System;
using System.Collections.Generic;
using System.Linq;

namespace Platformer
{
    public class QuestsController: IUpdateble
    {
        public event Action<int> QuestComplite = delegate (int i) { };

        private List<CollectableQuest> _collectableQuests = new List<CollectableQuest>();

        public QuestsController(QuestsConfig questsConfig, IPlayerDataForQuests playerDataForQuests)
        {
            var collectableQuestsFactory = new CollectableQuestsFactory();

            foreach (var config in questsConfig.CollectableQuestConfigs)
            {
                CollectableQuest quest = null;
                switch (config.CollectableItems)
                {
                    case CollectableItems.Coins:
                        quest = collectableQuestsFactory.Create(config, playerDataForQuests);
                        break;
                }

                if (quest is null) return;
                _collectableQuests.Add(quest);
                quest.QuestComplite += OnAnyQuestComplite;
            }
        }

        private void OnAnyQuestComplite(int questID, QuestTypes questType)
        {
            QuestComplite.Invoke(questID);
            Unsubscribe(questID, questType);
        }

        private void Unsubscribe(int questID, QuestTypes questType)
        {
            switch (questType)
            {
                case QuestTypes.Collectable:
                    _collectableQuests.FirstOrDefault(quest => quest.QuestModel.QuestID == questID).QuestComplite -= OnAnyQuestComplite;
                    break;
            }
        }

        public void Update(float deltaTime)
        {
            foreach(var quest in _collectableQuests)
            {
                quest.Update();
            }
        }
    }
}