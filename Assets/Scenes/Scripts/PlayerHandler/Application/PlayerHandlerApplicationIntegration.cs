
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

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="thisObj"></param>
    public PlayerHandlerApplicationIntegration(GameObject thisObj)
    {
        _playerHandlerInput = new PlayerHandlerInput();
        _playerHandlerApi = new PlayerHandlerApi();


        ComponentSet(thisObj);
        _playerHandlerAnimation = new PlayerHandlerAnimation(_playerHandlerApi.PlayerHandlerAnimator);

    }
    #region Setコンポーネント
    void ComponentSet(GameObject thisObj)
    {
        _playerHandlerApi.PlayerHandlerTransform = thisObj.GetComponent<Transform>();
        _playerHandlerApi.PlayerHandlerRectTransform = thisObj.GetComponent<RectTransform>();
        _playerHandlerApi.PlayerHandlerAnimator = _playerHandlerApi.PlayerHandlerTransform.GetComponent<Animator>();
        _playerHandlerApi.PlayerHandlerImage=_playerHandlerApi.PlayerHandlerTransform.GetComponent<Image>();
    }
    #endregion

    #region Getコンポーネント
    public Transform GetTransForm() => _playerHandlerApi.PlayerHandlerTransform;
    public Image GetImage() => _playerHandlerApi.PlayerHandlerImage;
    public RectTransform GetRectTransForm() => _playerHandlerApi.PlayerHandlerRectTransform;
    #endregion

    #region Input
    /// <summary>
    ///!Input.GetMouseButton(0);
    /// </summary>
    /// <returns></returns>
    public bool GetInputSearchingAi()=> _playerHandlerInput.InputSearchingAi();
    public bool GetInputHoldingAi() =>_playerHandlerInput.InputHoldingAi();
    public bool GetInputCarryingAi() => _playerHandlerInput.InputCarryingAi();
    public bool GetInputTalkingAi()=>_playerHandlerInput.InputTalkingAi();

    #endregion

    #region Anim
    public void GetNormalAnimPlay()=> _playerHandlerAnimation.NormalAnimPlay();

    #endregion


}