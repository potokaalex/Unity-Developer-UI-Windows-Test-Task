using CodeBase.Lobby.Data;
using CodeBase.Lobby.WindowsManager;

namespace CodeBase.Lobby.Main
{
    public class LobbyMainAdapter : ILobbyCloseCurrentWindowAdapter
    {
        private readonly LobbyWindowsManager _windowsManager;
        private readonly LobbyModel _model;

        public LobbyMainAdapter(LobbyWindowsManager windowsManager, LobbyModel model)
        {
            _windowsManager = windowsManager;
            _model = model;
        }

        public void Initialize(LobbyMainView mainView)
        {
            var data = _model.GetGameData();

            mainView.SetCoinsCount(data.TicketsCount);
        }

        public void ToggleCurrentWindow(LobbyWindowType windowType) => _windowsManager.ToggleCurrentWindow(windowType);

        public void CloseCurrentWindow() => _windowsManager.CloseCurrentWindow();
    }
}