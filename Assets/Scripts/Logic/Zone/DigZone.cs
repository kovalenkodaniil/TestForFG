using Logic.Player;

namespace Logic.Zone
{
    public class DigZone : Zone
    {
        protected override void ChangeBackpackValue(PlayerBackpack player)
        {
            player.TakeItem();

            base.ChangeBackpackValue(player);
        }
    }
}
