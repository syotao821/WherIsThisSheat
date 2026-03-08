using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 発射ボタンを押した時の実装
/// </summary>
public class BusHassyaUiButton : MonoBehaviour
{
	Button hassyaButton;
	BusController busController;
	public void SetStart()
	{
		hassyaButton = GetComponent<Button>();
		busController = FindFirstObjectByType<BusController>();
		//発車ボタンが押されるたびに実行される
		hassyaButton.onClick.AddListener(OnClickHassya);
	}

	/// <summary>
	/// 発車ボタンが押されたとき
	/// </summary>
	public void OnClickHassya()
	{
		//ドア閉め→発車のアニメーション再生
		busController.PlayBusAnimation(BusController.BUSANIMATION.CLOSEDOOR);

		UiManager.Instance.CountAiGroup();
	}
}
