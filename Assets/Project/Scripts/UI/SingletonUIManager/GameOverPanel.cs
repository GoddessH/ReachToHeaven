using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    //

    public void Active()
    {
        GameManager.FreezeScreen();
        gameObject.SetActive(true);
    }

    public void Deactive()
    {
        GameManager.UnFreezeScreen();
        gameObject.SetActive(false);
    }
}
