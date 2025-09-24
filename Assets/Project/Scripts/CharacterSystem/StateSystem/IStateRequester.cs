using UnityEngine;

public interface IStateRequester
{
    //

    public void RequestState();

    public void SetupStaticContext();
    public void SetupDynamicContext();
}
