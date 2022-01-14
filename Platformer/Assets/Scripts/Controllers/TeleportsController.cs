using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class TeleportsController: IUpdateble
    {
        private SpriteAnimatorController _teleportsAnimatorController;
        private List<TeleportView> _teleports = new List<TeleportView>();
        private List<ITriggerObject> _triggerTeleportObjects;
        
        public List<ITriggerObject> TriggerTeleportObjects { get => _triggerTeleportObjects; }

        public TeleportsController(TeleportsProtoModel teleportsProtoModel)
        {
            _teleportsAnimatorController = new SpriteAnimatorController(teleportsProtoModel.SpriteAnimatorConfig);

            var teleports = teleportsProtoModel.TeleportsPairs;
            for (int i = 0; i < teleports.Count; i++)
            {
                var firstTeleportInPair = new TeleportView(teleports[i].TeleportFirst, 
                                                           teleports[i].TeleportSecond, teleports[i].TeleportFirstSpriteRenderer, 
                                                           teleportsProtoModel.TeleportOffset);
                _teleports.Add(firstTeleportInPair);
                _teleportsAnimatorController.StartAnimation(firstTeleportInPair.SpriteRenderer, AnimState.Idle, true);

                var secondTeleportInPair = new TeleportView(teleports[i].TeleportSecond, 
                                                            teleports[i].TeleportFirst, teleports[i].TeleportSecondSpriteRenderer, 
                                                            teleportsProtoModel.TeleportOffset);
                _teleports.Add(secondTeleportInPair);
                _teleportsAnimatorController.StartAnimation(secondTeleportInPair.SpriteRenderer, AnimState.Idle, true);
            }

            _triggerTeleportObjects = new List<ITriggerObject>(_teleports);
        }

        public void Update(float deltaTime)
        {
            _teleportsAnimatorController.Update(deltaTime);
        }
    }
}