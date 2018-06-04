using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioClip Cursor;
    public AudioClip Drop;
    private AudioSource AU;
    public AudioClip Balloon;
    public AudioClip LinClear;
    private bool IsMute = false;
    private Ctrl ctrl;

    private void Awake()
    {
        AU = GetComponent<AudioSource>();
        ctrl = GetComponent<Ctrl>();
    }
    public void PlayLineClear()
    {
        PlayAudio(LinClear);
    }

    public void PlayBalloon()
    {
        PlayAudio(Balloon);
    }
    public void PlayCursor()
    {
        PlayAudio(Cursor);
    }
    public void PlayDrop()
    {
        PlayAudio(Drop);
    }
    private void PlayAudio(AudioClip Clip)
    {
        if (IsMute) return;
        AU.clip = Clip;
        AU.Play();
    }
    public void OnAudioButtonClick()
    {
        IsMute = !IsMute;
        ctrl.view.SetMuteActive(IsMute);
        if (IsMute == false)
            PlayCursor();
    }

}
