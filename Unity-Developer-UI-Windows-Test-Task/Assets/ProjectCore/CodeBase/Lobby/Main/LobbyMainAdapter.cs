using System;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.WindowsManager;

namespace CodeBase.Lobby.Main
{
    public class LobbyMainAdapter : ILobbyCloseCurrentWindowAdapter, IDisposable
    {
        private readonly LobbyWindowsManager _windowsManager;
        private readonly LobbyModel _model;
        private LobbyMainView _mainView;

        public LobbyMainAdapter(LobbyWindowsManager windowsManager, LobbyModel model)
        {
            _windowsManager = windowsManager;
            _model = model;
        }

        public void Initialize(LobbyMainView mainView)
        {
            var data = _model.GetGameData();
            _mainView = mainView;

            _model.OnTicketsCountChanged += SetCoinsCount;
            SetCoinsCount(data.PlayerProgress.TicketsCount);
        }

        public void Dispose() => _model.OnTicketsCountChanged -= SetCoinsCount;

        public void ToggleCurrentWindow(LobbyWindowType windowType) => _windowsManager.ToggleCurrentWindow(windowType);

        public void CloseCurrentWindow() => _windowsManager.CloseCurrentWindow();

        public void SetCoinsCount(int count) => _mainView.SetCoinsCount(count);
    }
}