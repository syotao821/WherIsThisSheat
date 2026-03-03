public class AiNormalStateAction : IAiState
{
    AiProvider _aiProvider;

    public AiNormalStateAction(AiProvider provider)
    {
        _aiProvider = provider;
        Entry();
    }

    public void Entry()
    {
        
    }

    public void Update()
    {
        // 通常の行動更新
        _aiProvider.UpdateEventOrderer();
    }

    public void Exit()
    {
       
    }
}