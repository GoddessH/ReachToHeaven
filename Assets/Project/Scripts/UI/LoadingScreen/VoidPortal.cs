using System.Collections;
using UnityEngine;

public class VoidPortal : MonoBehaviour
{
    //
    private NextSceneLoader m_nextSceneLoader;

    private void Awake()
        => m_nextSceneLoader = GetComponent<NextSceneLoader>();

    private void OnEnable()
        => StartCoroutine(LoadSceneRoutine());

    private IEnumerator LoadSceneRoutine()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        m_nextSceneLoader.LoadNextScene();
    }
}
