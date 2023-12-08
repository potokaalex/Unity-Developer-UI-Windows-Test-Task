using CodeBase.Lobby.Data;
using CodeBase.Lobby.WindowsManager;

namespace CodeBase.Lobby.Main
{
    public class LobbyMainAdapter: ILobbyCloseCurrentWindowAdapter
    {
        private readonly LobbyWindowsManager _windowsManager;

        public LobbyMainAdapter(LobbyWindowsManager windowsManager) => _windowsManager = windowsManager;

        public void Initialize(LobbyMainView mainView, LobbyAudioManager audioManager) => mainView.Initialize(this, audioManager);

        public void ToggleCurrentWindow(LobbyWindowType windowType) => _windowsManager.ToggleCurrentWindow(windowType);

        public void CloseCurrentWindow() => _windowsManager.CloseCurrentWindow();
    }
}