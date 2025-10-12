using System.Collections;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    //
    [SerializeField] private TextMeshProUGUI m_tmPro;
    private string m_label = "FPS: ";

    private void OnEnable()
        => StartCoroutine(StartCounting());

    private void OnDisable()
        => StopAllCoroutines();

    private IEnumerator StartCounting()
    {
        while(true)
        {
            m_tmPro.text = m_label + (int)(1 / Time.unscaledDeltaTime);
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
