using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLevelManager : IInitializable
{

    private const string GameLevelName = "GameLevel";
    private const string LastCompletedLevel = "LastLevelCompleted";

    private int _currentPlayLevelIndex = 1;
    
    public void Initialize()
    {
        int nextLevel = FindNextLevelIndex();
        _currentPlayLevelIndex = nextLevel;
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartCurrentPlayLevel()
    {
        int nextLevel = FindNextLevelIndex();
        var sceneName = GetPlayLevelScenenameForIndex(nextLevel);

        SceneManager.LoadScene(sceneName);
    }

    private int FindNextLevelIndex()
    {
        int levelIndex = 1;

        if (PlayerPrefs.HasKey(LastCompletedLevel))
        {
            levelIndex = PlayerPrefs.GetInt(LastCompletedLevel);
            levelIndex++;

            var maxLevelIndex = GetMaxScenesCount();
            if (levelIndex >= maxLevelIndex)
            {
                levelIndex = maxLevelIndex;
            }
        }
        return levelIndex;
    }

    private string GetPlayLevelScenenameForIndex(int levelIndex)
    {
        return GameLevelName + levelIndex;
    }

    private int GetMaxScenesCount()
    {
        return SceneManager.sceneCountInBuildSettings - 1;
    }

    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeToNextLevel()
    {
        _currentPlayLevelIndex++;
        
        int maxLevel = GetMaxScenesCount();

        if (_currentPlayLevelIndex > maxLevel)
            _currentPlayLevelIndex = maxLevel;

        var levelName = GetPlayLevelScenenameForIndex(_currentPlayLevelIndex);
        SceneManager.LoadScene(levelName);
    }

    public void SetCurrentSceneAsFinished()
    {
        PlayerPrefs.SetInt(LastCompletedLevel, _currentPlayLevelIndex);
        PlayerPrefs.Save();
    }
}