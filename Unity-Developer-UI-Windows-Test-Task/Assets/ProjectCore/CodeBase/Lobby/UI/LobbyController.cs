using System;

namespace CodeBase.Lobby.UI
{
    public class LobbyController : IDisposable
    {
        private readonly LobbyModel _model;
        private LobbyView _view;

        public LobbyController(LobbyModel model) => _model = model;

        public void Initialize(LobbyView lobbyView)
        {
            _view = lobbyView;
            SetCoinsCount(_model.TicketsCount.Value);
            _model.TicketsCount.OnChanged += SetCoinsCount;
        }

        public void Dispose() => _model.TicketsCount.OnChanged -= SetCoinsCount;

        private void SetCoinsCount(int count) => _view.SetCoinsCount(count);
    }
}