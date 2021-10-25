using System;
using UnityEngine;

namespace Targets
{
    [Serializable]
    public class TargetData
    {
        public ETargetType TargetType;

        public BaseTargetView Target;
    }
}
