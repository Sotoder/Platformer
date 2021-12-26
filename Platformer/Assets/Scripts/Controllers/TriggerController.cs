using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class TriggerController
    {
        public event Action GetCoin = delegate () { };
        public event Action<int, Vector2> Teleportation = delegate (int offset, Vector2 teleportationPosition) { };
        public event Action<Levels> LoadNextLevel = delegate (Levels nextLevel) { };

        private PlayerView _playerView;
        private Dictionary<TriggerObjectTypes, List<ITriggerObject>> _triggeredObjectsLists = new Dictionary<TriggerObjectTypes, List<ITriggerObject>>();

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
                        if(objectsList.Key == TriggerObjectTypes.Coin)
                        {
                            GetCoin.Invoke();
                        }
                        else if(objectsList.Key == TriggerObjectTypes.Teleport)
                        {
                            var teleportObject = objectsList.Value[i] as ITriggerTeleportObject;
                            Teleportation.Invoke(teleportObject.TeleportationOffset, teleportObject.PairObjectPosition);
                        }

                        else if (objectsList.Key == TriggerObjectTypes.EndLevel)
                        {
                            var endLevelObject = objectsList.Value[i] as ITriggerEndLevelPortalObject;
                            Teleportation.Invoke(0, endLevelObject.NextLevelStartPosition);
                            LoadNextLevel.Invoke(endLevelObject.NextLevelType);
                        }
                        break;
                    }
                }
            }
        }

        public TriggerController AddTriggerdObjects (TriggerObjectTypes objectType, List<ITriggerObject> gameObjects)
        {
            _triggeredObjectsLists.Add(objectType, gameObjects);

            return this;
        }

        public TriggerController AddTriggerdObjects(TriggerObjectTypes objectType, ITriggerObject gameObject)
        {
            _triggeredObjectsLists.Add(objectType, new List<ITriggerObject> {gameObject});

            return this;
        }
    }
}