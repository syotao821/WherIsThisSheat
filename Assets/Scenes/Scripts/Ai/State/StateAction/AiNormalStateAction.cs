using UnityEngine;

public class AiNormalStateAction : IAiState
{
    AiProvider _aiProvider;
    static int _animNum = 1;
    AiRunTimeData _runtimeData;

	public AiNormalStateAction(AiProvider provider)
    {
        _aiProvider = provider;
        Entry();
    }

    public void Entry()
    {
		_aiProvider.GetApplicationProvider().GetApplication().GetAiTransform().eulerAngles = new Vector3(306, 180, 357);//カメラのほうを向くように回転
        _aiProvider.GetApplicationProvider().GetApplication().SelectAnimationPlay(_animNum);
        _animNum++;
        if(_animNum == 3)
        {
            _animNum = 1;
		}
	}

	public void Update()
    {
        // 通常の行動更新
        _aiProvider.UpdateEventOrderer();

		//_aiProvider.GetRuntimeData()
	}

    public void Exit()
    {
       
    }
}