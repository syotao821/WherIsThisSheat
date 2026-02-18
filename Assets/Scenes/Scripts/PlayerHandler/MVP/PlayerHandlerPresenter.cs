using UnityEngine;
public class PlayerHandlerPresenter 
{

    PlayerHandlerModel _playerHandlerModel;
    PlayerHandlerView _playerHandlerView;


    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="_playerHandlerView"></param>
    public PlayerHandlerPresenter(PlayerHandlerView _playerHandlerView, GameObject thisObj)
    {
        this._playerHandlerModel =new PlayerHandlerModel();
        this._playerHandlerView = new PlayerHandlerView();
        this._playerHandlerView = _playerHandlerView;
        ComponentSet(thisObj);
    }

    void ComponentSet(GameObject thisObj)
    {
        _playerHandlerModel.PlayerHandleTransform=thisObj.GetComponent<Transform>();
        _playerHandlerModel.Animator = _playerHandlerModel.PlayerHandleTransform.GetComponent<Animator>();

    }


    public PlayerHandlerModel GetPlayerHandlerModel() => _playerHandlerModel;
    public PlayerHandlerView GetPlayerHandlerView() => _playerHandlerView;

}