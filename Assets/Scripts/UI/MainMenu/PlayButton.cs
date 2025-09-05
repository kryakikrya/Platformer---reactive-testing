using UnityEngine.SceneManagement;
using UnityEngine;

public sealed class PlayButton : MonoBehaviour
{

    const int GameSceneId = 1;
    public void ChangeScene()
    {
        SceneManager.LoadScene(GameSceneId);
    }
}
