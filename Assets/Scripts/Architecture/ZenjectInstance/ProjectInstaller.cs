using Manager;
using UnityEngine;
using Zenject;

namespace Code
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private AudioManager _audioManage;

        public override void InstallBindings()
        {
            BindResourcesLoader();
            BindAudioManage();
            BindSceneLoader();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<SceneLoader>()
                .FromNew()
                .AsSingle();
        }

        private void BindAudioManage()
        {
            Container
                .Bind<AudioManager>()
                .FromComponentInNewPrefab(_audioManage)
                .AsSingle();
        }

        private void BindResourcesLoader()
        {
            Container
                .Bind<GameobjectLoader>()
                .FromNew()
                .AsSingle();

            Container
                .Bind<SpriteLoader>()
                .FromNew()
                .AsSingle();
        }
    }
}