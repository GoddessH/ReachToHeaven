using UnityEngine;

public class UnscaledTimeAnimator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
    }

}
