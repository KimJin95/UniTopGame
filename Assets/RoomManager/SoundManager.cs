using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGMType { Title, InGame, InBoss, None }
public enum SEType { GameClear, GameOver, Shoot }
public class SoundManager : MonoBehaviour
{
    #region SingleTon
    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public static BGMType playingBGM = BGMType.None;

    [SerializeField] AudioClip[] bgmClips;
    [SerializeField] AudioClip[] seClips;

    AudioSource myAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlayBGM(BGMType type)
    {
        if (playingBGM!=type)
        {
            playingBGM = type;
            myAudio.clip = bgmClips[(int)type];
            myAudio.Play();

        }
    }
    public void StopBGM()
    {
        myAudio.Stop();
        playingBGM = BGMType.None;
    }

    public void SEPlay(SEType type)
    {
        myAudio.PlayOneShot(seClips[(int)type]);
    }
}
