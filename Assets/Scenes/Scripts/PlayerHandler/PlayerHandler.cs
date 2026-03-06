using UnityEngine;


public class PlayerHandler : MonoBehaviour, IGameInit
{
    PlayerHandlerStateContext _context;
    PlayerHandlerProvider _probider;
    [SerializeField] PlayerHandlerView _view;

    public int InitOrder =>0;

    void IGameInit.GameInit()
    {
        _context = new PlayerHandlerStateContext();
        _probider = new PlayerHandlerProvider(_view, this.gameObject);
        _context.Init(this, PLAYERHANDLERSTATE.SEARCHINGAI,_probider);
    }
    void Update()=> _context.Update();
    void FixedUpdate()=> _context.FixedUpdate();

    void OnDestroy()=> _probider.GetPlayerHnadlerLogicProvider().Dispose();
    public void SearchingAi() => SetState(PLAYERHANDLERSTATE.SEARCHINGAI);
    public void CarryingAi() => SetState(PLAYERHANDLERSTATE.CARRYINGAI);
    public void HoldingAi() => SetState(PLAYERHANDLERSTATE.HOLDINGAI);
    public void TalkingtoAi() => SetState(PLAYERHANDLERSTATE.TALKINGTOAI);



    void SetState(PLAYERHANDLERSTATE state)
    {
        _context.ChangeState(state);

    }

}