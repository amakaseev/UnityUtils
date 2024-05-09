using UnityEngine;

namespace UnityUtils {

  [System.Serializable]
  public class SoundCategory {
    public string name;
    public SoundData[] sounds;

    public bool Play(AudioSource audioSource, string name) {
      foreach(var sound in sounds) {
        if (sound.name == name) {
          sound.Play(audioSource);
          return true;
        }
      }
      return false;
    }
  }

}
