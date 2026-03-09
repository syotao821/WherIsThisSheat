using UnityEngine;

public class AiNormalStateAction : IAiState
{
    AiProvider _aiProvider;
	int _animNum=Random.Range(0,3);
    bool isSeatAnim = false;
	bool isGathering = false;
	int myGrouID = -1;
	Vector3 seatScale = new Vector3(0.7f, 0.7f, 0.7f);
	public AiNormalStateAction(AiProvider provider)
    {
        _aiProvider = provider;
        Entry();
    }

    public void Entry()
    {
		_aiProvider.GetApplicationProvider().GetApplication().GetAiTransform().eulerAngles = new Vector3(306, 180, 357);//カメラのほうを向くように回転
        _aiProvider.GetApplicationProvider().GetApplication().SelectAnimationPlay(_animNum);
      

		//自身のグループIDを取得しておく（バス停に集まるのはグループ単位で行うため）
		myGrouID = _aiProvider.GetAiSpawnData().GroupId;

		//バスのドアが開き終わったタイミングでイベント発火
		//バスの子オブジェクトにセット
		BusController.Instance.OnBussChildSet += () =>
		{
			if (UiManager.Instance.CheckAiGroup(myGrouID))
			{
				//_aiProvider.GetAiLogicProvider().GetAiLogickIntegration().ChildBinder();
			}
		};

		//バスの発車して見えなくなったタイミングでイベント発火
		//バスの子オブジェクトにセット
		BusController.Instance.OnBussResetChildSet += () =>
		{
			_aiProvider.GetAiLogicProvider().GetAiLogickIntegration().ResetParent();
		};
	}

	public void Update()
    {
        // 通常の行動更新
        _aiProvider.UpdateEventOrderer();

		//バス停に集まるのは初回のみ
		if (UiManager.Instance.CheckAiGroup(myGrouID))
		{
			if (!isGathering)
			{
				_aiProvider.GetAiLogicProvider().GetAiLogickIntegration().AiWalk();
				isGathering = true;
			}
		}

		if (_aiProvider.GetAiLogicProvider().GetAiLogickIntegration().IsSeat())
		{
			_aiProvider.GetRuntimeData().IsSeated = true;
		}
		else
		{
            _aiProvider.GetRuntimeData().IsSeated = false;

        }

        //座れる状態の時
        if (_aiProvider.GetRuntimeData().IsSeated)
		{
            _animNum = Random.Range(3, 7);

            if (isSeatAnim)
			{
				isSeatAnim = false;
				_aiProvider.GetApplicationProvider().GetApplication().GetAiTransform().eulerAngles = new Vector3(0, 90, 0);//バス正面を向くように回転

                _aiProvider.GetApplicationProvider().GetApplication().SelectAnimationPlay(_animNum);

                _aiProvider.GetApplicationProvider().GetApplication().GetAiTransform().localScale = seatScale;


            }


        }
		else
		{

			//座ってなかったら
			if (!isSeatAnim)
			{

                _animNum = Random.Range(0, 3);

                _aiProvider.GetApplicationProvider().GetApplication().GetAiTransform().eulerAngles = new Vector3(306, 180, 357);//カメラのほうを向くように回転

				//１回しか流れてほしくないからフラグで管理
				isSeatAnim = true;
                _aiProvider.GetApplicationProvider().GetApplication().SelectAnimationPlay(_animNum);

                _aiProvider.GetApplicationProvider().GetApplication().GetAiTransform().localScale = Vector3.one;

            }


        }


	}

    public void Exit()
    {
		BusController.Instance.OnBussChildSet -= () => { };
		BusController.Instance.OnBussResetChildSet -= () => { };
	}
}