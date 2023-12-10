using System;
using CodeBase.Project.Services.WindowsManagerService;
using CodeBase.UI.Model;
using Zenject;

namespace CodeBase.Lobby.Main
{
    public class LobbyMainAdapter : IInitializable, IDisposable
    {
        private readonly UIModel _model;
        private readonly LobbyMainUIFactory _lobbyMainUIFactory;
        private readonly WindowsManager _windowsManager;
        private LobbyMainView _mainView;

        public LobbyMainAdapter(UIModel model, LobbyMainUIFactory lobbyMainUIFactory, WindowsManager windowsManager)
        {
            _model = model;
            _lobbyMainUIFactory = lobbyMainUIFactory;
            _windowsManager = windowsManager;
        }

        public void Initialize()
        {
            _mainView = _lobbyMainUIFactory.CreateView();

            _mainView.Initialize(_model.ReadOnlyData.PlayerProgress.TicketsCount);
            _model.OnTicketsCountChanged += SetCoinsCount;

            _windowsManager.Initialize(_mainView.GetViewsRoot());
        }

        public void Dispose() => _model.OnTicketsCountChanged -= SetCoinsCount;

        private void SetCoinsCount(int count) => _mainView.SetCoinsCount(count);
    }
}