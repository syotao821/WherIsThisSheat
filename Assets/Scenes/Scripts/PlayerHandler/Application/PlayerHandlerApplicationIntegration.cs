
using UnityEngine.UI;
using UnityEngine;
/// <summary>
/// アプリケーションの依存の機能群
/// </summary>
public class PlayerHandlerApplicationIntegration
{
    PlayerHandlerInput _playerHandlerInput;
    PlayerHandlerApi _playerHandlerApi;
    PlayerHandlerAnimation _playerHandlerAnimation;
    public PlayerHandlerApplicationIntegration(GameObject thisObj)
    {
        _playerHandlerInput = new PlayerHandlerInput();
        _playerHandlerApi = new PlayerHandlerApi();
        ComponentSet(thisObj);
        _playerHandlerAnimation = new PlayerHandlerAnimation(_playerHandlerApi.Animator);

    }
    #region コンポーネント
    void ComponentSet(GameObject thisObj)
    {
        _playerHandlerApi.PlayerHandleTransform = thisObj.GetComponent<Transform>();
        _playerHandlerApi.Animator = _playerHandlerApi.PlayerHandleTransform.GetComponent<Animator>();
        _playerHandlerApi.PlayerHandlerImage=_playerHandlerApi.PlayerHandleTransform.GetComponent<Image>();
    }


    public Transform GetTransForm() => _playerHandlerApi.PlayerHandleTransform;
    public Image GetImage() => _playerHandlerApi.PlayerHandlerImage;
    #endregion

    #region Input
    public bool GetInputSearchingAi()=> _playerHandlerInput.InputSearchingAi();
    public bool GetInputHoldingAi() =>_playerHandlerInput.InputHoldingAi();
    public bool GetInputCarryingAi() => _playerHandlerInput.InputCarryingAi();
    public bool GetInputTalkingAi()=>_playerHandlerInput.InputTalkingAi();

    #endregion

    #region Anim
    public void GetNormalAnimPlay()=> _playerHandlerAnimation.NormalAnimPlay();

    #endregion


}