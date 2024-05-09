using UnityEngine;

namespace UnityUtils {

  [CreateAssetMenu(fileName = "SoundData", menuName = "AudioManager/SoundData")]
  public class SoundData: ScriptableObject {
    public AudioClip sound;
    public bool randomPitch = true;
    public bool randomVolume = true;
    [Range(0, 1)] public float volume = 1;

    public void Play(AudioSource audioSource) {
      audioSource.pitch = randomPitch ? 1 : Random.Range(0.95f, 1.05f);
      audioSource.PlayOneShot(sound, volume * (randomVolume? Random.Range(0.9f, 1f) : 1));
      audioSource.pitch = 1;
    }
  }

}
