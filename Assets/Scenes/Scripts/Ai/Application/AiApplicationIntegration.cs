using UnityEngine;
public class AiApplicationIntegration
{
    AiAnimation _aiAnimation;
    AiApi _aiApi;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="thisObj"></param>
    public AiApplicationIntegration(GameObject thisObj)
    {
        _aiApi = new AiApi();
        SetComponent(thisObj);
        _aiAnimation = new AiAnimation(_aiApi.AiAnimator);
        
    }


    #region Setコンポーネント

    void SetComponent(GameObject thisObj)
    {
        _aiApi.AiTransform = thisObj.transform.GetComponent<Transform>();
        _aiApi.AiAnimator = _aiApi.AiTransform.GetComponent<Animator>();
    }

    #endregion

    #region Getコンポーネント
    public Transform GetAiTransform()
    {
        return _aiApi.AiTransform;
    }

    public Animator GetAiAnimator()
    {
        return _aiApi.AiAnimator;
    }

    #endregion


    #region アニメーション
    public void GetIdleAnimPlay() => _aiAnimation.IdleAnimPlay();
    #endregion

}