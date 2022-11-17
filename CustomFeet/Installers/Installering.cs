using System;
using Zenject;

namespace CustomFeet.Installers
{
    public class Installering :Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CustomFeetMenuController>().AsSingle();
        }
    }
}
