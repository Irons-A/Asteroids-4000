using Core.Bootstrap;
using Core.Configuration;
using Core.UserInput;
using Gameplay.Environment;
using Player;
using Player.Configuration;
using Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay.Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindConfiguration();
            BindInputSystem();
            BindPlayer();
            BindGameSystems();
        }

        private void BindConfiguration()
        {
            Container.Bind<IConfigProvider>().To<JsonConfigProvider>().AsSingle();

            Container.Bind<InputConfig>()
                .FromMethod(context =>
                    context.Container.Resolve<IConfigProvider>().LoadConfig<InputConfig>("Configs/InputConfig"))
                .AsSingle();

            Container.Bind<PlayerConfig>()
                .FromMethod(context =>
                    context.Container.Resolve<IConfigProvider>().LoadConfig<PlayerConfig>("Configs/PlayerConfig"))
                .AsSingle();
        }

        private void BindInputSystem()
        {
            Container.Bind<InputStrategyFactory>().AsSingle();
            Container.Bind<InputDetector>().AsSingle().NonLazy();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerMovementController>()
                .FromMethod(context =>
                    new PlayerMovementController(
                        context.Container.Resolve<PlayerConfig>(),
                        Vector2.zero))
                .AsSingle();

            Container.Bind<PlayerFacade>().AsSingle().NonLazy();
        }

        private void BindGameSystems()
        {
            Container.Bind<ScreenWrapper>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Core.Bootstrap.GameBootstrap>().AsSingle().NonLazy();
        }
    }
}
