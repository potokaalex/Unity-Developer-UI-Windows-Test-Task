﻿using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.DailyBonus
{
    public class DailyBonusUIFactory : IInitializable
    {
        private readonly IInstantiator _instantiator;
        private readonly DailyBonusAdapter _adapter;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private LobbyConfig _config;

        public DailyBonusUIFactory(IInstantiator instantiator, DailyBonusAdapter adapter,
            LobbyStaticDataProvider staticDataProvider)
        {
            _instantiator = instantiator;
            _adapter = adapter;
            _staticDataProvider = staticDataProvider;
        }

        public void Initialize() => _config = _staticDataProvider.GetConfig();

        public DailyBonusCongratsView CreateCongratsView(Transform root)
        {
            var prefab = _config.DailyBonusCongratsViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<DailyBonusCongratsView>(prefab);

            item.transform.SetParent(root, false);

            return item;
        }

        public DailyBonusOverviewView CreateOverviewView(Transform root)
        {
            var prefab = _config.DailyBonusOverviewViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<DailyBonusOverviewView>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(_adapter, _config.DailyBonusCountItemPresets);

            return item;
        }

        public void CreateCountItemView(Transform root, LobbyDailyBonusCountItemPreset preset)
        {
            var prefab = _config.DailyBonusCountItemViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<DailyBonusCountItemView>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(preset);
        }
    }
}