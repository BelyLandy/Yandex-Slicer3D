using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public enum Scene
    {
        Intro,
        MainMenu,
        GameplayScene,
        LoadingScreen,
        YandexGames,
        Empty
    }

    public static Scene scene;

    [System.Obsolete]
    public void Load()
    {
        if(scene == Scene.LoadingScreen)
        {
            SceneManager.LoadScene(scene.ToString());
            Loader.scene = Loader.Scene.Empty;
        }       
        else if (scene == Scene.YandexGames)
        {
            OpenWeb.UrlOpen("https://yandex.ru/games/developer/71007#redir-data=%7B%22http_ref%22%3A%22https%253A%252F%252Fyandex.ru%252Fgames%252F%2523app%253D264551%22%2C%22rn%22%3A411168666%7D");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Loader.scene = Loader.Scene.Empty;
        }
        MSHDTCTR.isNeedEventHappened = false;
    }
}
