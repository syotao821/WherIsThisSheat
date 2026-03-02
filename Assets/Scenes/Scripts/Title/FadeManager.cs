using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// フェードしながらシーン遷移するためのクラス
/// </summary>
public class FadeManager : MonoBehaviour
{
	CanvasGroup canvasGroup;
	bool isLoading = false;
	float fadeTime = 0.3f;

	private void Awake()
	{
		if (canvasGroup == null)
			canvasGroup = transform.GetChild(0).GetComponent<CanvasGroup>();

		//シーン開始時にフェードインする
		canvasGroup.alpha = 1f;
		StartCoroutine(Fade(1, 0, 0.5f));
	}


	public IEnumerator Fade(float _from, float _to, float _duration)
	{
		float time = 0;
		canvasGroup.alpha = _from;

		while (time < _duration)
		{
			canvasGroup.alpha = Mathf.Lerp(_from, _to, time / _duration);
			time += Time.deltaTime;
			yield return null;
		}

		canvasGroup.alpha = _to;
	}

	/// <summary>
	/// 外部からシーン遷移を呼び出すための関数
	/// 基本的にはButtonインスペクターのOnClick()から呼び出すことを想定している
	/// </summary>
	/// <param name="_sceneIndex"></param>
	public void LoadScene(int _sceneIndex)
	{
		if (isLoading) return;//2重タップ防止

		isLoading = true;
		StartCoroutine(LoadRoutine(_sceneIndex, fadeTime));
	}

	private IEnumerator LoadRoutine(int _scene, float _time)
	{
		//フェードアウト
		yield return Fade(0, 1, _time);

		//シーンロード
		yield return SceneManager.LoadSceneAsync(_scene);
	}
}