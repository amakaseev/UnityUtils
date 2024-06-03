using System.Collections.Generic;
using UnityEngine;

namespace UnityUtils {

  public struct ActiveSound {
    public float finishTime;
    public SoundData sound;
  }

  [RequireComponent(typeof(AudioSource))]
  public class AudioManager: Singleton<AudioManager> {
    AudioSource audioSource;
    List<ActiveSound> activeSounds = new();

    public static bool IsMusicMute => Instance.audioSource.mute;
    public static bool IsSoundMute => Instance.audioSource.mute;

    protected override void Awake() {
      base.Awake();
      audioSource = GetComponent<AudioSource>();
    }

    void Update() {
      float currentTime = Time.time;
      for (int i = activeSounds.Count - 1; i >= 0; --i) {
        if (activeSounds[i].finishTime <= currentTime) {
          activeSounds.RemoveAt(i);
        }
      }
    }

    bool RequestPlaySound(SoundData sound) {
      foreach (var activeSound in activeSounds) {
        if (activeSound.sound == sound) return false;
      }
      return true;
    }

    public static void PlaySound(SoundData soundData) {
      if (!soundData) {
        return;
      }

      if (Instance.RequestPlaySound(soundData)) {
        soundData.Play(Instance.audioSource);
        Instance.activeSounds.Add(new ActiveSound {
          finishTime = Time.time + soundData.sound.length * soundData.sameTime,
          sound = soundData
        });
      }
    }
    
    public static void MusicMute(bool mute) {
      Instance.audioSource.mute = mute;
    }

    public static void SoundMute(bool mute) {
      Instance.audioSource.mute = mute;
    }
  }

}
