using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton
    public static SoundManager current;
    private void Awake()
    {
        current = this;
        soundTimerDictionary = new Dictionary<Sound, float>();
        //soundTimerDictionary[Sound.Footstep] = 0;
    }
    #endregion

    public SoundAudioClip[] soundAudioClips;

    public enum Sound
    {
        ActivatingPortal,
        Mining,
        Footstep,
        PickingUp,
        PlaceOnPedestal,
        Warp,
        MonsterCharge,
        PlayerDeath,
        MenuClick,
        MonsterStep
        
    }

    Dictionary<Sound, float> soundTimerDictionary;

    GameObject oneShotGameObject;
    AudioSource oneShotAudioSource;

    public void PlaySound(Sound sound)
    {
        if (CanPlaySound(sound))
        {
            if(oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("Sound");
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
            }
            oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
        }
    }
    public void PlaySound(Sound sound, Vector3 position)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();

            Destroy(soundGameObject, audioSource.clip.length);
        }
    }
    bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default:
                return true;
           /* case Sound.Footstep:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTiemPlayed = soundTimerDictionary[sound];
                    float soundLength = GetAudioClip(sound).length;
                    if (lastTiemPlayed + soundLength < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                        return false;
                }*/
              //  else
                    return true;
        }

    }

    AudioClip GetAudioClip(Sound sound)
    {
        foreach (SoundAudioClip soundAudioClip in soundAudioClips)
            if (soundAudioClip.sound == sound)
                return soundAudioClip.audioClip;
        Debug.LogError("Nie znaleziono " + sound);
        return null;
    }

    [System.Serializable]
    public class SoundAudioClip
    {
        public Sound sound;
        public AudioClip audioClip;
    }

    public void MenuClickSound()
    {
        SoundManager.current.PlaySound(SoundManager.Sound.MenuClick);
    }
}