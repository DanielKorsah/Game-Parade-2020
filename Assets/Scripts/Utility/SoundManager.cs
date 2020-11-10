using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource MusicPlayer;
    [SerializeField] private AudioSource SoundPlayer;

    public static SoundManager Instance { get; private set; }

    public static UnityEvent GameSceneStartEvent = new UnityEvent();
    public static UnityEvent ConfirmEvent = new UnityEvent();
    public static UnityEvent ButtonEvent = new UnityEvent();


    public List<AudioClip> Music = new List<AudioClip>();
    public AudioClip Confirm;
    public AudioClip Button;

    // Start is called before the first frame update
    void Awake()
    {
        //singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        GameSceneStartEvent.AddListener(PlayEvilMusic);
        ButtonEvent.AddListener(PlayButton);
        ConfirmEvent.AddListener(PlayConfirm);

    }

    public void PlayEvilMusic()
    {
        MusicPlayer.clip = Music[1];
        MusicPlayer.Play();
    }

    public void PlayButton()
    {
        SoundPlayer.clip = Button;
        SoundPlayer.Play();
    }

    public void PlayConfirm()
    {
        SoundPlayer.clip = Confirm;
        SoundPlayer.Play();
    }




}
