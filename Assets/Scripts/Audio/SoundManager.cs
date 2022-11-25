using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class SoundManager : MonoBehaviour
{
    public List<AudioSource> channels;
    private List<AudioClip> audioClips;

    // Start is called before the first frame update
    void Awake()
    {
        channels = GetComponents<AudioSource>().ToList();
        audioClips = new List<AudioClip>();
        InitializeSoundFX();
    }

    private void InitializeSoundFX()
    {
        audioClips.Add(Resources.Load<AudioClip>("Audio/JumpSound"));
        audioClips.Add(Resources.Load<AudioClip>("Audio/HurtSound"));
        audioClips.Add(Resources.Load<AudioClip>("Audio/DeathSound"));
        audioClips.Add(Resources.Load<AudioClip>("Audio/MainSoundTrack"));
    }
   
    public void PlaySoundFX(Channel channel, Sound sound)
    {
        channels[(int)channel].clip = audioClips[(int)sound];
        channels[(int)channel].Play();
    }

    public void PlayMusic()
    {
        channels[(int)Channel.MUSIC].clip = audioClips[(int)Sound.MUSIC];
        channels[(int)Channel.MUSIC].volume = 0.25f;
        channels[(int)Channel.MUSIC].loop = true;
        channels[(int)Channel.MUSIC].Play();
    }
}
