using System;
using UnityEngine;

public class AiEventOrderer:IDisposable
{
    ToAiEventListener _toAiEventListener;
    AiDataEventListener _aiDataEventListener;

    Transform _targetTransform;
    AiDataEventHub _aiDataEventHub;
    AiData _aiData;
    AiRunTimeData _aiRunTimeData;
    AiEventReciverHub _aiEventReciverHub;
    public AiEventOrderer()
    {
        _toAiEventListener=new ToAiEventListener();
        _aiDataEventListener=new AiDataEventListener();
        _aiDataEventHub = new AiDataEventHub();
        _aiEventReciverHub=new AiEventReciverHub();
    }

    public void UpdateSelectAi(Transform _targetTransform,AiData _aiData,AiRunTimeData _aiRunTimeData)
    {
        this. _targetTransform = _toAiEventListener._toAiEventCallback.Invoke();
        if(this._targetTransform==null)return;
        Debug.Log(this._targetTransform);
        if(this._targetTransform== _targetTransform)
        {
            _aiDataEventHub.RaiseAiData(_aiData);
            _aiDataEventHub.RaiseAiRunTimeData(_aiRunTimeData);

            this._aiData =_aiDataEventListener._getAiData.Invoke();
            this._aiRunTimeData = _aiDataEventListener._getAiRunTaimeData.Invoke();
            _aiEventReciverHub.RaiseOnReciverAiData(this._aiData);
            _aiEventReciverHub.RaiseOnReciverAiRunTimeData(this._aiRunTimeData);

        }
    }


    public void Dispose()
    {
        _toAiEventListener.Dispose();
        _aiDataEventListener.Dispose();
    }

}