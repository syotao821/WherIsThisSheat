using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 発射ボタンを押した時の実装
/// </summary>
public class BusHassyaUiButton : MonoBehaviour
{
	Button hassyaButton;
	BusController busController;
	bool isClicked = false;
	public void SetStart()
	{
		hassyaButton = GetComponent<Button>();
		busController = FindFirstObjectByType<BusController>();
		//発車ボタンが押されるたびに実行される
		hassyaButton.onClick.AddListener(OnClickHassya);

		//次のグループｽﾀｰﾄ
		BusController.Instance.OnBussHassyaAnimeEnd += () =>
		{
			UiManager.Instance.CountAiGroup();
		};

		BusController.Instance.OnBussDoorOpen += () =>
		{
			hassyaButton.interactable = true;
			isClicked = false;
		};
	}

	/// <summary>
	/// 発車ボタンが押されたとき
	/// </summary>
	public void OnClickHassya()
	{      
		if(isClicked) return;//二重クリック防止

		hassyaButton.interactable = false;//ボタンを押せなくする
		isClicked = true;

		//SE再生
		UiSound.Instance.Play(UiClips.Instance.audioClip[1]);

		//ドア閉め→発車のアニメーション再生
		busController.PlayBusAnimation(BusController.BUSANIMATION.CLOSEDOOR);
	}
}
