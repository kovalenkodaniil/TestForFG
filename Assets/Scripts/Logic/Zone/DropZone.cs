using Logic.Player;
using UnityEngine.Events;

namespace Logic.Zone
{
    public class DropZone : Zone
    {
        public event UnityAction ItemDroped;

        protected override void ChangeBackpackValue(PlayerBackpack player)
        {
            player.GetItem(DropItem);

            base.ChangeBackpackValue(player);
        }

        private void DropItem() =>
            ItemDroped?.Invoke();
    }
}
