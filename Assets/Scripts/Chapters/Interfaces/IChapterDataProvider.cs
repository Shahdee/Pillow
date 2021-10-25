using Screens;

namespace Chapters
{
    public interface IChapterDataProvider
    {
        ChapterData GetChapterData(int chapterId);

        ScreenData GetScreenData(int chapterId, int screenId);

        bool HasScreen(int chapterId);
        
        ScreenData GetScreenData(ChapterData chapter, int screenId);
    }
}