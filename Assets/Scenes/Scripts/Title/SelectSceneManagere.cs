using UnityEngine;
using UnityEngine.UI;

public class SelectSceneManagere : MonoBehaviour
{
	FadeManager fadeManager;
	[SerializeField] Button[] stageButtons = new Button[3];
	bool isLoading = false;//2重タップ防止

	void Start()
    {
		BGMManager.Instance.PlayBGM(0);
		fadeManager = FindFirstObjectByType<FadeManager>();
		isLoading = false;

		for (int i = 0; i < stageButtons.Length; i++)
		{
			int stageID = i;//クロージャ対策
			stageButtons[i].onClick.AddListener(() => OnClickStage(stageID));
		}
	}


	void OnClickStage(int _stageID)
	{
		if (isLoading) return;
		isLoading = true;

		//SE再生
		UiSound.Instance.Play(UiClips.Instance.audioClip[0], isUnique: true);

		switch (_stageID)
		{
			case 0:
				//ステージ1へ
				break;
			case 1:
				//ステージ2へ
				break;
			case 2:
				//ステージ3へ
				break;
		}

		fadeManager.LoadScene(2);
	}

}
