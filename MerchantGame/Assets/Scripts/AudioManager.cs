using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource[] sources;
    public List<AudioClip> musicClips;
    public List<AudioClip> soundClips;

    public enum SoundType {Sound, Music};
    public enum MusicClipName{BackgroundMusic, BattleMusic, TitleMusic}; 
    public enum SoundClipName{MagicMist, SwordStrike, Death, PanelOpen, PanelClose, Buy, Sell, Select, Deselect}; 
    // Start is called before the first frame update
    void Start()
    {
        sources = GetComponents<AudioSource>(); 
        sources[(int)SoundType.Music].loop = true;
        sources[(int)SoundType.Sound].loop = false;
    }

    public static AudioManager Get()
    {
        AudioManager gm = null;

        if(GameObject.FindWithTag("Managers") != null)
        {
            gm = GameObject.FindWithTag("Managers").GetComponent<AudioManager>();
        }

        return gm;
    }

    
    public void PlayMusic(MusicClipName name){
        sources[(int)SoundType.Music].clip = musicClips[(int)name];
        sources[(int)SoundType.Music].Play();
    }
    public void PlaySound(SoundClipName name){
        sources[(int)SoundType.Sound].clip = soundClips[(int)name];
        sources[(int)SoundType.Sound].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
