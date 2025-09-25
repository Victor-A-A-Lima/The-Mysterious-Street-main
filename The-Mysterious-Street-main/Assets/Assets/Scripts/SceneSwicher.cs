using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwicher : MonoBehaviour
{
    public void SceneScwitch(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
