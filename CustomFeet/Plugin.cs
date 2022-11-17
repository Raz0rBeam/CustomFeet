using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System.Reflection;
using CustomFeet.Configuration;
using UnityEngine;
using SiraUtil.Zenject;
using BeatSaberMarkupLanguage;
using IPALogger = IPA.Logging.Logger;
using CustomFeet.Installers;
using UnityEngine.SceneManagement;

namespace CustomFeet
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        [Init]
        public void Init(IPALogger logger, Zenjector zenject, IPA.Config.Config conf)
        {
            Instance = this;
            Log = logger;
            Log.Info("CustomFeet initialized.");

            PluginConfig.Instance = conf.Generated<PluginConfig>();

            zenject.Install<Installering>(Location.Menu);
            zenject.Install<Installering>(Location.Singleplayer);

            LoadFootPlane();
            // Loading foot plane isnt working. please work
        }
        /*private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
        {
            if (arg1.name == "MainMenu" && isDone == false)
            {
                LoadFootPlane();
                Log.Critical("IOSDJFOIHJDFIOJIOSDF");
            }
        }*/

        public GameObject _gameObject;
        public bool isDone = false;
        public static GameObject instantiate;
        public void LoadFootPlane()
        {
            var loadedAssetBundle = AssetBundle.LoadFromMemory(Utilities.GetResource(Assembly.GetExecutingAssembly(), "CustomFeet.Assets.customfeet"));
            _gameObject = loadedAssetBundle.LoadAsset<GameObject>("CustomFeet");
            instantiate = Object.Instantiate(_gameObject);
            Object.DontDestroyOnLoad(instantiate);
            instantiate.name = "NewFeet";
            loadedAssetBundle.Unload(false);
            instantiate.SetActive(true);
        }
    }
}
