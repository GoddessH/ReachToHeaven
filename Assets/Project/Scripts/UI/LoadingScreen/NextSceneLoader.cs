using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    //
    [Tooltip("Chose the next scene will be loaded")]
    [SerializeField] private SceneLibrary m_nextScene;

    [Tooltip("Switch to LoadScene first then ")]
    public void LoadNextScene()
    {
        LoadingSceneData.NextSceneToLoad = m_nextScene;
        SceneManager.LoadScene((int)SceneLibrary.LoadingScene, LoadSceneMode.Single);
    }
}
