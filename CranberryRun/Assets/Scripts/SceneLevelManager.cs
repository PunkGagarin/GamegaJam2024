using UnityEngine.SceneManagement;

public class SceneLevelManager
{

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartCurrentPlayLevel()
    {
        //todo: отслеживать уровень для старта.
        SceneManager.LoadScene("GameScene");
    }

    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}