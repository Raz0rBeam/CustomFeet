using BeatSaberMarkupLanguage;
using CustomFeet.Configuration;
using CustomFeet.Installers;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using SiraUtil.Zenject;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

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

            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        }
        // Loading foot plane isnt working. please work
        private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
        {
            if (arg1.name == "MainMenu" && isDone == false)
            {
                LoadFootPlane();
                Log.Critical("IOSDJFOIHJDFIOJIOSDF");
            }
        }

        public GameObject _gameObject;
        public bool isDone = false;
        public static GameObject instantiate;
        public AssetBundle loadedAssetBundle = AssetBundle.LoadFromMemory(Utilities.GetResource(Assembly.GetExecutingAssembly(), "CustomFeet.Assets.feet"));
        public void LoadFootPlane()
        {
            _gameObject = loadedAssetBundle.LoadAsset<GameObject>("Plane");
            instantiate = Object.Instantiate(_gameObject);
            Object.DontDestroyOnLoad(instantiate);
            instantiate.name = "NewFeet";
            instantiate.transform.position = new Vector3(0f, 0.05f, 0f);
            instantiate.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            instantiate.SetActive(false);
            isDone = true;
        }
    }
}
