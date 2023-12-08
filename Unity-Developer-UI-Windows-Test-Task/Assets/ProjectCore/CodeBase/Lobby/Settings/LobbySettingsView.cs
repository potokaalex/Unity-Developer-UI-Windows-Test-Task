using ProjectCore.CodeBase.Utilities.UI;

namespace ProjectCore.CodeBase.Lobby.Settings
{
    public class LobbySettingsView : WindowBase
    {
        public void Initialize() => Close();

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