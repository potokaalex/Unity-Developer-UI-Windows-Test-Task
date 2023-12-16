using CodeBase.Common.Services.AudioManagerService;
using CodeBase.Common.Services.SaveLoaderService;
using CodeBase.Lobby.UI;
using Unity.Services.Core;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby
{
    public class LobbyStartup : MonoBehaviour
    {
        private LobbyUIFactory _lobbyUIFactory;
        private GameDataSaveLoader _gameDataSaveLoader;
        private LobbyModel _lobbyModel;
        private AudioManager _audioManager;

        [Inject]
        public void Construct(LobbyUIFactory lobbyUIFactory, GameDataSaveLoader gameDataSaveLoader,
            LobbyModel lobbyModel, AudioManager audioManager)
        {
            _lobbyUIFactory = lobbyUIFactory;
            _gameDataSaveLoader = gameDataSaveLoader;
            _lobbyModel = lobbyModel;
            _audioManager = audioManager;
        }

        private void Start()
        {
            InitializeUnityServices();
            LoadGameData();

            _lobbyUIFactory.Create();
        }

        private void OnDestroy() => _gameDataSaveLoader.Save();

        private void InitializeUnityServices()
        {
            try
            {
                UnityServices.InitializeAsync(new InitializationOptions());
            }
            catch
            {
                Debug.LogError("Unity services initialization failed!");
            }
        }

        private void LoadGameData()
        {
            _gameDataSaveLoader.RegisterWatcher(_audioManager);
            _gameDataSaveLoader.RegisterWatcher(_lobbyModel);
            _gameDataSaveLoader.Load();
        }
    }
}