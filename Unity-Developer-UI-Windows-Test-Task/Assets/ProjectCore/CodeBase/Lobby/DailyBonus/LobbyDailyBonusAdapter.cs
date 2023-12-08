using System;

namespace CodeBase.Lobby.DailyBonus
{
    public class LobbyDailyBonusAdapter
    {
        private readonly LobbyModel _model;

        public LobbyDailyBonusAdapter(LobbyModel model)
        {
            _model = model;
        }

        public void Initialize(LobbyDailyBonusCongratsView congratsView)
        {
            var data = _model.GetGameData();
            var currentDate = DateTime.Now.ToOADate();
            var difference = currentDate - data.LastEntryOADate;

            if(difference < 1)
                congratsView.Open();
        }
    }
}