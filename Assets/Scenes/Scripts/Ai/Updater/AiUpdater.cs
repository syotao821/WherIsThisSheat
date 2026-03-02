using UnityEngine;
using System.Collections.Generic;
public class AiUpdater:MonoBehaviour,IGameInit
{

    AiUpdaterEventListener _aiUpdaterEventListener;
    IReadOnlyList<AiBase> _updaterAiBaseList;
    public int InitOrder =>1;

    public void GameInit()
    {
        AiDiContainer.Register(this);
    }

    public void InitDI(AiUpdaterEventListener _aiUpdaterEventListener)
    {
        this._aiUpdaterEventListener = _aiUpdaterEventListener;
    }
    private void Update()
    {
        if (_updaterAiBaseList == null)
            _updaterAiBaseList = _aiUpdaterEventListener._getAiBaseList.Invoke();

        foreach (AiBase _aiBase in _updaterAiBaseList)
        {
            _aiBase.Update();
        }
    }

    void OnDestroy()
    {
        foreach (AiBase _aiBase in _updaterAiBaseList)
        {
            _aiBase.Dispose();
        }
    }
}