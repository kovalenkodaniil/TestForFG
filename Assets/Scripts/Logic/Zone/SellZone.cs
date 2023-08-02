using Logic.Player;

namespace Logic.Zone
{
    public class SellZone : Zone
    {
        protected override void ChangeBackpackValue(PlayerBackpack player)
        {
            player.GetItem();

            base.ChangeBackpackValue(player);
        }
    }
}
