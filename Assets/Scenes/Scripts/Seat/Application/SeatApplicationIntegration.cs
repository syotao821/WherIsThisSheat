using UnityEngine;
/// <summary>
/// 席のアプリケーションの統合ファイル
/// </summary>
public class SeatApplicationIntegration
{
    SeatAnimation _seatAnimation;
    SeatApi _seatApi;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="thisObj"></param>
    public SeatApplicationIntegration(GameObject thisObj)
    {
        _seatApi = new SeatApi();
        SetComponent(thisObj);
        _seatAnimation = new SeatAnimation(_seatApi.SeatAnimator);

    }


    #region Setコンポーネント

    void SetComponent(GameObject thisObj)
    {
        _seatApi.SeatTransfom = thisObj.transform.GetComponent<Transform>();
        _seatApi.SeatAnimator = _seatApi.SeatTransfom.GetComponent<Animator>();
    }

    #endregion

    #region Getコンポーネント
    public Transform GetAiTransform()
    {
        return _seatApi.SeatTransfom;
    }

    public Animator GetAiAnimator()
    {
        return _seatApi.SeatAnimator;
    }

    #endregion

    #region アニメーション
    public void GetIdleAnimPlay() => _seatAnimation.IdleAnimPlay();
    #endregion

}