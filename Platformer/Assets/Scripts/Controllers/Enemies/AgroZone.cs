using System;
using UnityEngine;

namespace Platformer
{
    public class AgroZone : MonoBehaviour
    {
        public event Action<Transform> PlayerInZone = delegate (Transform target) { };
        public event Action PlayerLeftZone = delegate () { };

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent<PlayerView>(out PlayerView playerView))
            {
                PlayerInZone.Invoke(playerView.Transform);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<PlayerView>(out PlayerView playerView))
            {
                PlayerLeftZone.Invoke();
            }
        }
    }
}
