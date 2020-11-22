using System;
using System.Collections.Generic;
using TofuCore.Service;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Initialization {
    public class ServiceRoot : AbstractGameServiceInitializer {
        private Dictionary<string, Action<ServiceRoot>> _sceneToInitFunctions = new Dictionary<string, Action<ServiceRoot>>
        {
            {"Menu", (root) =>
            {
                BindServices binder = new BindServices();
                binder.ConfigureCoreServices(root.ServiceContext);
                binder.ConfigureMenuOnlyServices(root.ServiceContext);

                root.ServiceContext.FullInitialization();
            }},
            {"Game", (root) =>
            {
                BindServices binder = new BindServices();
                binder.ConfigureCoreServices(root.ServiceContext);
                binder.ConfigureGameServices(root.ServiceContext);

                root.ServiceContext.FullInitialization();
            }}
        };

        private void OnEnable() {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += HandleSceneLoaded;
        }

        private void OnDisable() {
            SceneManager.sceneLoaded -= HandleSceneLoaded;
        }

        protected override void HandleUnityObjects() {
        }

        protected override void RegisterPayloads() {
        }

        protected override void BindServices() {
        }

        protected override void InitServices() {
        }

        private void HandleSceneLoaded(Scene scene, LoadSceneMode mode) {
            _sceneToInitFunctions[scene.name](this);
        }
    }
}