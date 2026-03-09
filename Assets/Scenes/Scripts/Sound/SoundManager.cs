using UnityEngine;
using System.Collections.Generic;

public abstract class SoundManager : MonoBehaviour
{
    [SerializeField]protected AudioSource audioSource;

    PriorityAudioClip lastPlayedClip = null;
    Dictionary<PriorityAudioClip, float> clipPlayTime = new Dictionary<PriorityAudioClip, float>();
    PriorityAudioClip currentlyPlayingClip = null;

    protected virtual void Awake()
    {

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    /// <summary>
    /// オーディオクリップを優先度や再生間隔を考慮して再生する
    /// </summary>
    /// <param name="clip">再生する優先度付きAudioClip</param>
    /// <param name="isUnique">連続して同じクリップの再生を防止するか</param>
    /// <param name="useInterval">再生インターバルを使うか</param>
    /// <param name="playInterval">インターバルの秒数</param>
    /// <param name="volume">再生音量（0～1）</param>
    /// <param name="useSurround">3D空間音響を使うか（true=3D音）</param>
    /// <param name="isOverrideAllowed">同じ優先度で再生中の音を上書き可能か</param>
    public void Play(PriorityAudioClip clip, bool isUnique = false, bool useInterval = false, float playInterval = 0f, float volume = 1f, bool useSurround = false, bool isOverrideAllowed = true)
    {
        // 同一の連続再生を防止
        if (isUnique && clip == lastPlayedClip) return;

        // インターバルチェック
        bool intervalPassed = true;
        if (useInterval && clipPlayTime.TryGetValue(clip, out float lastTime))
        {
            intervalPassed = Time.time - lastTime >= playInterval;
            if (!intervalPassed) return;
        }

        // 現在再生中のclipのpriorityと比較
        if (audioSource.isPlaying && currentlyPlayingClip != null)
        {
            if (clip.priority < currentlyPlayingClip.priority)
            {
                return; // 優先度が低いなら再生しない
            }

            if (clip.priority == currentlyPlayingClip.priority && !isOverrideAllowed)
            {
                // 同じ優先度で上書き不可なら再生しない
                return;
            }

            // 同じclipでインターバルが経過していれば上書き再生
            if (clip == currentlyPlayingClip && useInterval && intervalPassed)
            {
                // 続行して再生処理へ
            }
        }

        // 空間オーディオ設定
        audioSource.spatialBlend = useSurround ? 1f : 0f;

        // 再生
        audioSource.clip = clip.clip;
        audioSource.volume = volume;
        audioSource.Play();

        // 状態保存
        currentlyPlayingClip = clip;

        if (lastPlayedClip != clip)
        {
            lastPlayedClip = clip;
        }

        if (useInterval)
        {
            clipPlayTime[clip] = Time.time;
        }
    }

}
