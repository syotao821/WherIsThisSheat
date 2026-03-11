using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Button startButton;
	FadeManager fadeManager;

    void Start()
    {
		BGMManager.Instance.PlayBGM(0);

		fadeManager = FindFirstObjectByType<FadeManager>();
		//スタートボタンが押されるたびに実行される
		startButton.onClick.AddListener(OnClickStart);
	}

	void OnClickStart()
	{
		//難易度シーンへ
		fadeManager.LoadScene(1);
	}
}
