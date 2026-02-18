using UnityEngine;

public class PlayerHandler : MonoBehaviour, IGameInit
{

    [SerializeField] PlayerHandlerView _view;
    PlayerHandlerPresenter _playerHandlerPresenter;
    void IGameInit.GameInit()
    {
        _playerHandlerPresenter = new PlayerHandlerPresenter(_view,this.gameObject);
    }
}