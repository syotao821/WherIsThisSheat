using UnityEngine;
using UnityEngine.UI;
public class PlayerHandlerPresenter 
{

    PlayerHandlerModel _playerHandlerModel;
    PlayerHandlerView _playerHandlerView;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="_playerHandlerView"></param>
    public PlayerHandlerPresenter(PlayerHandlerView _playerHandlerView,Image _playerHandlerImage)
    {
        this._playerHandlerModel =new PlayerHandlerModel();
        this._playerHandlerView = _playerHandlerView;
        SetSprite(_playerHandlerImage);
    }


    void SetSprite(Image _playerHandlerImage)
    {
        _playerHandlerImage.sprite = _playerHandlerView.HandSprite;
    }
}