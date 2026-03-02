using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeManager : MonoBehaviour
{
	CanvasGroup canvasGroup;
	bool isLoading = false;
	float fadeTime = 0.3f;

	private void Awake()
	{
		if (canvasGroup == null)
			canvasGroup = transform.GetChild(0).GetComponent<CanvasGroup>();

		canvasGroup.alpha = 1f;
		StartCoroutine(Fade(1, 0, 0.5f));
	}


	public IEnumerator Fade(float from, float to, float duration)
	{
		float time = 0;
		canvasGroup.alpha = from;

		while (time < duration)
		{
			canvasGroup.alpha = Mathf.Lerp(from, to, time / duration);
			time += Time.deltaTime;
			yield return null;
		}

		canvasGroup.alpha = to;
	}

	public void LoadScene(int sceneIndex)
	{
		if (isLoading) return;//2重タップ防止

		isLoading = true;
		StartCoroutine(LoadRoutine(sceneIndex, fadeTime));
	}

	private IEnumerator LoadRoutine(int scene, float time)
	{
		yield return Fade(0, 1, time);

		yield return SceneManager.LoadSceneAsync(scene);
	}
}