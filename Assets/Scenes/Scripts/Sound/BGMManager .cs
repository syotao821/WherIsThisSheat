using UnityEngine;
using System.Collections;

/// <summary>
/// シングルトンで管理するBGM再生マネージャー（フェード対応）
/// </summary>
public class BGMManager : SingletonBehaviour<BGMManager>
{
    [SerializeField] AudioSource bgmSource;       // BGM再生用のAudioSource
    [SerializeField] AudioClip[] bgmClips;        // BGMクリップ配列
    [SerializeField] float fadeDuration = 1f;     // フェード時間（秒）

   public static int currentIndex = -1;                        // 現在のBGMインデックス
    Coroutine fadeCoroutine = null;               // フェード処理用コルーチン
    float originalVolume = 0.25f;                 // 音量の初期値（0fだった場合用に初期値定義）
    float startVolume;


    public void OnEnable()
    {
        currentIndex = -1;
    }
    /// <summary>
    /// 指定したBGMをフェード付きで再生
    /// </summary>
    public void PlayBGM(int index)
    {
        if (index < 0 || index >= bgmClips.Length) return;
        if (index == currentIndex) return;

        currentIndex = index;

        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
            fadeCoroutine = null;
        }

        fadeCoroutine = StartCoroutine(FadeAndPlay(bgmClips[index]));
    }

    /// <summary>
    /// フェードアウト → クリップ切替 → フェードイン
    /// </summary>
    IEnumerator FadeAndPlay(AudioClip newClip)
    {
        startVolume = bgmSource.volume;
        if (startVolume == 0f) startVolume = originalVolume;

        // フェードアウト
        for (float t = 0; t < fadeDuration; t +=Time.deltaTime)
        {
            bgmSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeDuration);
            yield return null;
        }
        bgmSource.volume = 0f;

        // BGM切り替え
        bgmSource.Stop();
        bgmSource.clip = newClip;

        if (newClip == null)
        {
            fadeCoroutine = null;
            yield break;
        }

        bgmSource.Play();

        // フェードイン
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            bgmSource.volume = Mathf.Lerp(0f, originalVolume, t / fadeDuration);
            yield return null;
        }

        bgmSource.volume = originalVolume;
        fadeCoroutine = null;
    }
}
