using System;
using System.Collections.Generic;
using CodeBase.Project.Data;
using CodeBase.Project.Data.Saved;
using CodeBase.Project.Services.SaveLoaderService;
using CodeBase.UI.DailyBonus;
using CodeBase.UI.Levels;
using CodeBase.UI.Settings;
using CodeBase.UI.Shop;

namespace CodeBase.Lobby.UI
{
    public class LobbyModel : IGameDataReader, IGameDataWriter, ISettingsModel, IDailyBonusModel, ILevelsModel,
        IShopModel
    {
        public EventField<int> TicketsCount { get; private set; }

        public EventField<bool> IsMusicActive { get; private set; }

        public EventField<bool> IsUISoundActive { get; private set; }

        public EventField<double> LastExitOADate { get; private set; }

        public EventField<int> ConsecutiveEntryCount { get; private set; }

        public EventField<int> CompletedLevelNumber { get; private set; }

        public EventField<List<string>> BoughtItemsIDs { get; private set; }

        public void OnGameDataLoad(SavedGameData data)
        {
            TicketsCount = new EventField<int>(data.PlayerProgress.TicketsCount);

            IsMusicActive = new EventField<bool>(data.Settings.IsMusicActive);
            IsUISoundActive = new EventField<bool>(data.Settings.IsUISoundActive);

            LastExitOADate = new EventField<double>(data.PlayerProgress.LastExitOADate);
            ConsecutiveEntryCount = new EventField<int>(data.PlayerProgress.ConsecutiveEntryCount);

            CompletedLevelNumber = new EventField<int>(data.PlayerProgress.CompletedLevelNumber);

            BoughtItemsIDs = new EventField<List<string>>(data.PlayerProgress.BoughtItemsIDs);
        }

        public void OnGameDataSave(SavedGameData data)
        {
            data.PlayerProgress.TicketsCount = TicketsCount.Value;

            data.Settings.IsMusicActive = IsMusicActive.Value;
            data.Settings.IsUISoundActive = IsUISoundActive.Value;

            data.PlayerProgress.LastExitOADate = DateTime.Now.ToOADate();
            data.PlayerProgress.ConsecutiveEntryCount = ConsecutiveEntryCount.Value;

            data.PlayerProgress.CompletedLevelNumber = CompletedLevelNumber.Value;
        }
    }
}