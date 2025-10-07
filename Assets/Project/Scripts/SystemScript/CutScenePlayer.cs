using System;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class CutScenePlayer : Singleton<CutScenePlayer>, ISubject<Action<PlayableDirector>>
{
    private PlayableDirector m_director;

    protected override void Awake()
    {
        m_director = GetComponent<PlayableDirector>();
        base.Awake();
    }

    public void PlayCutscene()
        => m_director.Play();

    public void StopCutScene()
        => m_director.Stop();

    #region Implement ISubject
    public void Subscribe(Action<PlayableDirector> subscriber)
        => m_director.paused += subscriber;
    public void UnSubscribe(Action<PlayableDirector> subscriber)
        => m_director.paused -= subscriber;
    #endregion
}
