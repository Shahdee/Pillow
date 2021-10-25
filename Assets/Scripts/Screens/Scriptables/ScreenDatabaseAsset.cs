using UnityEngine;
using System.Collections.Generic;

namespace Screens
{
    [CreateAssetMenu(fileName = "ScreenDatabase",  menuName = "SO/Screens/ScreenDatabase")]
    public class ScreenDatabaseAsset : ScriptableObject
    {
        public ScreenData ScreenData => _screenData;
        
        [SerializeField] private ScreenData _screenData;
    }
}