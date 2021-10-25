using System;
using System.Collections.Generic;
using Targets;
using UnityEngine;

namespace Screens
{
    [Serializable]
    public class ScreenData
    {
        public string Name;
        
        public List<TargetDatabaseAsset> TargetDatas;

        public Sprite ScreenBackground;
    }
}