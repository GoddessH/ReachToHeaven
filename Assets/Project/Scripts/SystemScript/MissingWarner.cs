using UnityEngine;

public static class MissingWarner
{
    //
    ///<param name="warningText">
    ///Do not add space! The LogWarning added space between parameter already!
    /// </param>
    public static void LogWarning<T, U>(T owner, string warningText, U missingReference)
    {
        Debug.Log($"{owner} {warningText} -> {missingReference}");
    }
}
