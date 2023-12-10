using System;

namespace CodeBase.Lobby.Main
{
    public class LobbyMainAdapter : IDisposable
    {
        private readonly LobbyModel _model;
        private LobbyMainView _mainView;

        public LobbyMainAdapter(LobbyModel model) => _model = model;

        public void Initialize(LobbyMainView mainView)
        {
            var data = _model.GetGameData();
            _mainView = mainView;

            _model.OnTicketsCountChanged += SetCoinsCount;
            SetCoinsCount(data.PlayerProgress.TicketsCount);
        }

        public void Dispose() => _model.OnTicketsCountChanged -= SetCoinsCount;

        public void SetCoinsCount(int count) => _mainView.SetCoinsCount(count);
    }
}