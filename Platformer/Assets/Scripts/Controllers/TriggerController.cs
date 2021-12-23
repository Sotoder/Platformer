using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class TriggerController
    {
        public event Action GetCoin = delegate () { };
        public event Action<int, Vector2> Teleportation = delegate (int offset, Vector2 teleportationPosition) { };

        private PlayerView _playerView;
        private Dictionary<TriggeredObjectTypes, List<ITriggerObject>> _triggeredObjectsLists = new Dictionary<TriggeredObjectTypes, List<ITriggerObject>>();

        public TriggerController(PlayerView playerView)
        {
            _playerView = playerView;
            _playerView.FoundTriggerObject += CheckTriggerObject;
        }

        private void CheckTriggerObject(Collider2D collider)
        {
            foreach(var objectsList in _triggeredObjectsLists)
            {
                for(int i = 0; i < objectsList.Value.Count; i++)
                {
                    if (collider.gameObject.GetInstanceID() == objectsList.Value[i].InstanceID)
                    {
                        if(objectsList.Key == TriggeredObjectTypes.Coin)
                        {
                            GetCoin.Invoke();
                        }
                        else if(objectsList.Key == TriggeredObjectTypes.Teleport)
                        {
                            var teleportObject = objectsList.Value[i] as ITriggerTeleportObject;
                            Teleportation.Invoke(teleportObject.TeleportationOffset, teleportObject.PairObjectPosition);
                        }
                        break;
                    }
                }
            }
        }

        public TriggerController AddTriggerdObjects (TriggeredObjectTypes objectType, List<ITriggerObject> gameObjects)
        {
            _triggeredObjectsLists.Add(objectType, gameObjects);

            return this;
        }
    }
}