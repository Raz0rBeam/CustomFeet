using BeatSaberMarkupLanguage;
using System;
using System.Reflection;
using UnityEngine;
using Zenject;

namespace CustomFeet
{
    public class CustomFeetMenuController : IInitializable, IDisposable
    {
        public void Initialize()
        {
            /*
            var feet = GameObject.CreatePrimitive(PrimitiveType.Plane);
            feet.name = "NewFeet";
            feet.transform.position = new Vector3(0f, 0.01f, 0f);
            feet.transform.localScale = new Vector3(0.03f, 1f, 0.03f);*/
        }

        public void Dispose()
        {
            //GameObject.Destroy(GameObject.Find("NewFeet"));
        }
    }
}
