using UnityEngine;

/// <summary>
/// ステートに回すためのアクセッサー
/// </summary>
public class PlayerHandlerProvider
{

    PlayerHandlerPresenter _playerHandlerPresenter;
    PlayerHandlerApplicationProvider _playerHandlerApplicationProvider;
    PlayerHandlerLogicProvider _playerHnadlerLogicProvider;
    public PlayerHandlerProvider(PlayerHandlerView _playerHandlerView, GameObject _playerHandlerObj)
    {
        _playerHandlerApplicationProvider = new PlayerHandlerApplicationProvider(_playerHandlerObj);
        _playerHandlerPresenter = new PlayerHandlerPresenter(_playerHandlerView, _playerHandlerApplicationProvider.GetApplication().GetImage());
        _playerHnadlerLogicProvider = new PlayerHandlerLogicProvider(_playerHandlerApplicationProvider.GetApplication(), _playerHandlerPresenter);

    }

    /// <summary>
    /// インスペクター上やプレイヤーのデータ
    /// </summary>
    /// <returns></returns>
    public PlayerHandlerPresenter GetPlayerHandlerPresenter() => _playerHandlerPresenter;

    /// <summary>
    /// コンポーネントなどのUnity依存のデータ
    /// </summary>
    /// <returns></returns>
    public PlayerHandlerApplicationProvider GetPlayerHandlerApplicationProvider() => _playerHandlerApplicationProvider;

    /// <summary>
    /// ロジック
    /// </summary>
    /// <returns></returns>
    public PlayerHandlerLogicProvider GetPlayerHnadlerLogicProvider() => _playerHnadlerLogicProvider;
}