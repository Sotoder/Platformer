using UnityEngine;

namespace PlatformerMVC
{
    public class CoinQuestModel : IQuestModel
    {

        private const string Tag = "Player";

        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(Tag);
        }
    }
}
