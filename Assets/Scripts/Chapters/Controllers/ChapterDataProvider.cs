using Screens;
using System.Linq;

namespace Chapters
{
    // to retrieve data from ChapterDatabaseAsset 
    
    public class ChapterDataProvider : IChapterDataProvider
    {
        private readonly ChapterDatabaseAsset _chapterDatabase;
        
        public ChapterDataProvider(ChapterDatabaseAsset chapterDatabase)
        {
            _chapterDatabase = chapterDatabase;
        }

        public ChapterData GetChapterData(int chapterId)
        {
            if (chapterId < 0 || chapterId >= _chapterDatabase.ChapterDatas.Count)
                return null;

            return _chapterDatabase.ChapterDatas[chapterId];
        }

        public ScreenData GetScreenData(int chapterId, int screenId)
        {
            var chapterData = GetChapterData(chapterId);
            if (chapterData == null || chapterData.ScreenDatas == null)
                return null;
        
            if (screenId < 0 || screenId >= chapterData.ScreenDatas.Count)
                return null;
        
            var screenDatabase = chapterData.ScreenDatas[screenId];
            return screenDatabase.ScreenData;
        }
        
        public ScreenData GetScreenData(ChapterData chapterData, int screenId)
        {
            if (chapterData == null || chapterData.ScreenDatas == null)
                return null;
        
            if (screenId < 0 || screenId >= chapterData.ScreenDatas.Count)
                return null;
        
            var screenDatabase = chapterData.ScreenDatas[screenId];
            return screenDatabase.ScreenData;
        }

        public bool HasScreen(int chapterId)
        {
            var chapterData = GetChapterData(chapterId);
            if (chapterData == null || chapterData.ScreenDatas == null)
                return false;

            return chapterData.ScreenDatas.Any();
        }
    }
}