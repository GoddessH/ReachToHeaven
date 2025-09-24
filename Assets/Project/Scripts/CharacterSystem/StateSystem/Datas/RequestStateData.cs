
///<summary>
///Note: Must initialize new TStateContext when create RequestStateData
/// </summary>
public class RequestStateData<TStateContext> where TStateContext : StateContext
{
    //
    public StateType Type;
    public TStateContext Context;

    public RequestStateData(StateType type)
    {
        Type = type;
    }


}
