using UnityEngine;
using System.Collections.Generic;


namespace Chapters
{
    [CreateAssetMenu(fileName = "ChapterDatabase",  menuName = "SO/Chapters/ChapterDatabase")]
    public class ChapterDatabaseAsset : ScriptableObject
    {
        public IReadOnlyList<ChapterData> ChapterDatas => _chapterDatas;
        
        [SerializeField] private List<ChapterData> _chapterDatas;
    }
}