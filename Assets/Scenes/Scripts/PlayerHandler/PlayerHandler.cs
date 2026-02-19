using UnityEngine;


public class PlayerHandler : MonoBehaviour, IGameInit
{
    PlayerHandlerStateContext _context;
    PlayerHandlerProvider _probider;
    [SerializeField] PlayerHandlerView _view;
    void IGameInit.GameInit()
    {
        _context = new PlayerHandlerStateContext();
        _probider = new PlayerHandlerProvider(_view, this.gameObject);
        _context.Init(this, PLAYERHANDLERSTATE.SEARCHINGAI,_probider);
    }
    void Update()=> _context.Update();
    void FixedUpdate()=> _context.FixedUpdate();



    public void Searchingai() => SetState(PLAYERHANDLERSTATE.SEARCHINGAI);
    public void Carryingai() => SetState(PLAYERHANDLERSTATE.CARRYINGAI);
    public void Holdingai() => SetState(PLAYERHANDLERSTATE.HOLDINGAI);
    public void Talkingtoai() => SetState(PLAYERHANDLERSTATE.TALKINGTOAI);



    void SetState(PLAYERHANDLERSTATE state)
    {
        _context.ChangeState(state);

    }
}