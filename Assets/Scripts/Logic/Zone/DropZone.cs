using Logic.Player;
using UnityEngine.Events;

namespace Logic.Zone
{
    public class DropZone : Zone
    {
        public event UnityAction ItemDroped;
        private int _droppedItemsTotalCount;

        public int DroppedItemsCount => _droppedItemsTotalCount;

        protected override void ChangeBackpackValue(PlayerBackpack player)
        {
            player.GetItem(DropItem);

            base.ChangeBackpackValue(player);
        }

        private void DropItem() 
        {
            _droppedItemsTotalCount++;
            ItemDroped?.Invoke();
        }
    }
}
