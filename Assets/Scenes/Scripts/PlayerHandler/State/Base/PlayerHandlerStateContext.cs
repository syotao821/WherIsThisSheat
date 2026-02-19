using System.Collections.Generic;

public class PlayerHandlerStateContext
{

    IPlayerHandlerState _currentState;    // 現在の状態
    // 状態のテーブル
    Dictionary<PLAYERHANDLERSTATE, IPlayerHandlerState> _stateTable;

    public void Init(PlayerHandler _player, PLAYERHANDLERSTATE _initState,PlayerHandlerProvider _playerHandlerProvider)
    {
        if (_stateTable != null) return; // 何度も初期化しない

        // 各状態選クラスの初期化
        Dictionary<PLAYERHANDLERSTATE, IPlayerHandlerState> table = new()
        {
            //            変更　　　変更
            { PLAYERHANDLERSTATE.SEARCHINGAI, new PlayerHnadlerSearchingAIState(_player,_playerHandlerProvider) },
            { PLAYERHANDLERSTATE.HOLDINGAI, new PlayerHnadlerHoldingAIState(_player,_playerHandlerProvider) },
            { PLAYERHANDLERSTATE.CARRYINGAI, new PlayerHnadlerCarryingAIState(_player,_playerHandlerProvider) },
            { PLAYERHANDLERSTATE.TALKINGTOAI, new PlayerHnadlerTalkingToAIState(_player,_playerHandlerProvider) },
           
        };
        _stateTable = table;
        ChangeState(_initState);
    }

    // 別の状態に変更する
    public void ChangeState(PLAYERHANDLERSTATE next)
    {
        if (_stateTable == null) return; // 未初期化なら無視
        if (!_stateTable.ContainsKey(next)) return; // 存在チェック

        // 同じ状態には遷移しない
        if (_currentState != null && _currentState.State == next)
            return;

        // 退場
        if (_currentState != null)
            _currentState.Exit();

        // 状態切り替え
        _currentState = _stateTable[next];
        // 入場
        _currentState.Entry();
    }

    // 現在の状態をUpdateする
    public void Update()
    {
        if (_currentState != null)
        {
            _currentState.Update();
        }
    }

    public void FixedUpdate()
    {

        if (_currentState != null)
        {
            _currentState.FixedUpdate();
        }
    }
}
