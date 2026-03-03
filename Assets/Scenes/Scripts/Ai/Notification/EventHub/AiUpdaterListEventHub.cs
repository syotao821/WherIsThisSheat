
public class AiUpdaterListEventHub
{
    public static event OnAiBase _onAiBase;
    public delegate void OnAiBase(AiBase _aiBase);

    public static event OnAiBaseListClear _onAiBaseClear;
    public delegate void OnAiBaseListClear();


    public void RaiseOnAiBase(AiBase _aiBase)
    {
        _onAiBase?.Invoke(_aiBase);
    }

    public void RaiseOnAiBaseListClear()
    {
        _onAiBaseClear?.Invoke();
    }
}