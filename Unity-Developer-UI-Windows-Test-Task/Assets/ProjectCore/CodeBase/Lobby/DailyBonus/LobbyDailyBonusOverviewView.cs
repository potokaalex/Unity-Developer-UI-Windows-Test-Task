﻿using System.Collections.Generic;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.WindowsManager;
using CodeBase.Utilities.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Lobby.DailyBonus
{
    public class LobbyDailyBonusOverviewView : WindowBase
    {
        [SerializeField] private LobbyDailyBonusGetWeeklyBonusButton _getWeeklyBonusButton;
        [SerializeField] private LobbyCloseCurrentWindowButton _closeWindowButton;
        [SerializeField] private Transform _countItemsSpawnRoot;
        [SerializeField] private TextMeshProUGUI _sliderProgressText;
        [SerializeField] private Slider _slider;

        private const int MaxSliderValue = 7;

        private LobbyDailyBonusUIFactory _dailyBonusUIFactory;

        [Inject]
        public void Construct(LobbyDailyBonusUIFactory dailyBonusUIFactory) =>
            _dailyBonusUIFactory = dailyBonusUIFactory;

        public void Initialize(LobbyDailyBonusAdapter dailyBonusAdapter,
            List<LobbyDailyBonusCountItemPreset> itemPresets)
        {
            _slider.maxValue = MaxSliderValue;
            
            _closeWindowButton.Initialize(dailyBonusAdapter);
            _getWeeklyBonusButton.Initialize();
            Close();

            for (var i = 0; i < 6; i++)
                _dailyBonusUIFactory.CreateCountItemView(_countItemsSpawnRoot, itemPresets[i]);
        }

        public void SetSliderProgress(int consecutiveDaysCount)
        {
            _sliderProgressText.text = $"{consecutiveDaysCount}/{MaxSliderValue}";
            _slider.value = consecutiveDaysCount;
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