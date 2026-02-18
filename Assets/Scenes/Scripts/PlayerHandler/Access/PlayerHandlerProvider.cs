using UnityEngine;

/// <summary>
/// ステートに回すためのアクセッサー
/// </summary>
public class PlayerHandlerProvider
{

    PlayerHandlerPresenter _playerHandlerPresenter;
    PlayerHandlerApplicationProvider _playerHandlerApplicationProvider;

    public PlayerHandlerProvider(PlayerHandlerView _playerHandlerView, GameObject _playerHandlerObj)
    {
        _playerHandlerPresenter = new PlayerHandlerPresenter(_playerHandlerView, _playerHandlerObj);
        _playerHandlerApplicationProvider = new PlayerHandlerApplicationProvider();
    }

    public PlayerHandlerPresenter GetPlayerHandlerPresenter() => _playerHandlerPresenter;
    public PlayerHandlerApplicationProvider GetPlayerHandlerApplicationProvider() => _playerHandlerApplicationProvider;

}