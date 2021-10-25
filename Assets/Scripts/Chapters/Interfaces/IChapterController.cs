using UnityEngine;
using System;

namespace Chapters
{
    public interface IChapterController
    {
        event Action<int> OnChapterLaunch;
        event Action<int> OnChapterComplete;
        
        bool LaunchChapter(int chapter);
    }
}