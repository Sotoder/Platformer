namespace Platformer
{
    public class CollectableQuestsFactory
    {
        public CollectableQuest Create (CollectableQuestConfig config, IPlayerDataForQuests data)
        {
            var quest = new CollectableQuest(config, data);
            return quest;
        }
    }
}