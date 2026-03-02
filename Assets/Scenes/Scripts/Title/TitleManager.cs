using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Button startButton;
	FadeManager fadeManager;

    void Start()
    {
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
