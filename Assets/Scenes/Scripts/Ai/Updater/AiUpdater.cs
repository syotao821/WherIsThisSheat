using UnityEngine;

public class AiUpdater:MonoBehaviour
{

    AiUpdaterEventListener _aiUpdaterEventListener;

    public void InitDI(AiUpdaterEventListener _aiUpdaterEventListener)
    {
        this._aiUpdaterEventListener = _aiUpdaterEventListener;
    }
    private void Update()
    {
        foreach (AiBase _aiBase in _aiUpdaterEventListener.GetAiBaseList())
        {
            _aiBase.Update();
        }
    }
}