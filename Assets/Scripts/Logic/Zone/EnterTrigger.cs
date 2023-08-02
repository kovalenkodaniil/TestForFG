using Logic.Player;
using UnityEngine;
using UnityEngine.Events;

namespace Logic.Zone
{
    [RequireComponent(typeof(BoxCollider))]

    public class EnterTrigger: MonoBehaviour
    {
        public event UnityAction<PlayerBackpack> PlayerEntered;
        public event UnityAction PlayerExited;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<PlayerBackpack>(out PlayerBackpack player))
                PlayerEntered?.Invoke(player);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<PlayerBackpack>(out PlayerBackpack player))
                PlayerExited?.Invoke();
        }
    }
}
