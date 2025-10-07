using UnityEngine;

///<summary>
///Must set m_isPersist
/// </summary>
public abstract class Singleton<T> : MonoBehaviour where T : Behaviour
{
    //
    protected static bool m_isPersisted;

    protected static T m_instance;
    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindAnyObjectByType<T>();
                if (m_instance == null) m_instance = SetupInstance();
            }
            return m_instance;
        }
    }

    protected virtual void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this as T;
            if (m_isPersisted) DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    protected static T SetupInstance()
    {
        GameObject instance = new GameObject(typeof(T).Name);
        if (m_isPersisted) DontDestroyOnLoad(instance.gameObject);
        return instance.AddComponent<T>();
    }
}
