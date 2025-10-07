using UnityEngine;

public static class GameManager
{
    //
    public static void FreezeScreen()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public static void UnFreezeScreen()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}
