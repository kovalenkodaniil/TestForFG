using Logic.Player;

namespace Logic.Zone
{
    public class BuyZone : Zone
    {
        protected override void ChangeBackpackValue(PlayerBackpack player)
        {
            player.TakeItem();

            base.ChangeBackpackValue(player);
        }
    }
}
