
public class ApplicationIntegration
{
    PlayerHandlerInput _playerHandlerInput;

    public ApplicationIntegration()
    {
        _playerHandlerInput = new PlayerHandlerInput();
    }

    #region Input
    public bool InputSearchingAi()=> _playerHandlerInput.InputSearchingAi();
    public bool InputHoldingAi() =>_playerHandlerInput.InputHoldingAi();
    public bool InputCarryingAi() => _playerHandlerInput.InputCarryingAi();
    public bool InputTalkingAi ()=>_playerHandlerInput.InputTalkingAi();

    #endregion
}