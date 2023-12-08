using CodeBase.Utilities.UI;

namespace CodeBase.Lobby.DailyBonus
{
    public class LobbyDailyBonusCongratsView : WindowBase
    {
        public void Initialize()
        {
            Close();
        }
        
        public override void Open()
        {
            base.Open();
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            base.Close();
            gameObject.SetActive(false);
        }
    }
}