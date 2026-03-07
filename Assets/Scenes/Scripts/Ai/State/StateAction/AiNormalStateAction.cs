using UnityEngine;

public class AiNormalStateAction : IAiState
{
    AiProvider _aiProvider;
    static int _animNum = 0;
    AiRunTimeData _runtimeData;
    bool isSeatAnim = false;
	bool isGathering = false;
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
            _animNum = 0;
		}


	}

	public void Update()
    {
        // 通常の行動更新
        _aiProvider.UpdateEventOrderer();

		//バス停に集まるのは初回のみ
		if(!isGathering)
		{
			_aiProvider.GetAiLogicProvider().GetAiLogickIntegration().AiWalk();
			isGathering = true;
		}

		Debug.Log("isSeatAnim "+isSeatAnim);

		//座れる状態の時
		if (_aiProvider.GetRuntimeData().IsSeated)
        {
            if(isSeatAnim)
            {
				isSeatAnim = false;
				_aiProvider.GetApplicationProvider().GetApplication().GetAiTransform().eulerAngles = new Vector3(0, 90, 0);//バス正面を向くように回転

				if (_animNum >= 0 && 4 > _animNum)
				{
					_animNum = 3;
				}

                _animNum++;

				if (_animNum == 7)
				{
					_animNum = 3;
				}
			}
			_aiProvider.GetApplicationProvider().GetApplication().SelectAnimationPlay(_animNum);


		}
		else
        {
			//座ってなかったら
			if (!isSeatAnim)
            {
                _animNum++;
				if (_animNum == 3)
				{
					_animNum = 0;
				}

				_aiProvider.GetApplicationProvider().GetApplication().GetAiTransform().eulerAngles = new Vector3(306, 180, 357);//カメラのほうを向くように回転

				//１回しか流れてほしくないからフラグで管理
				isSeatAnim = true;
			}
            
            _aiProvider.GetApplicationProvider().GetApplication().SelectAnimationPlay(_animNum);

			Debug.Log("座ってないときのアニメーションID "+_animNum);
		}


	}

    public void Exit()
    {
       
    }
}