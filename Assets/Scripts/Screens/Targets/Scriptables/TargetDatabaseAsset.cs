using UnityEngine;

namespace Targets
{
    [CreateAssetMenu(fileName = "TargetDatabase",  menuName = "SO/Targets/TargetDatabase")]
    public class TargetDatabaseAsset : ScriptableObject
    {
        public TargetData TargetData => _targetData;
        [SerializeField] private TargetData _targetData;
    }
}
