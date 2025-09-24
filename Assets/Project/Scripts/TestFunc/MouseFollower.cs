using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    //

    private void Update()
    {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
