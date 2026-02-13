using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerManager : Singleton<VideoPlayerManager>
{
    [SerializeField] private GameObject _container;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _playPauseButton;
    [SerializeField] private Sprite _playSprite;
    [SerializeField] private Sprite _pauseSprite;

    private bool _playing;

    private void Awake()
    {
        GameManager.Instance.InitEvent.AddListener(ActionOnInit);
        _videoPlayer.prepareCompleted += PlayVideo;
        _slider.onValueChanged.AddListener(ActionOnSliderValueChanged);
    }


    public void ActionOnInit()
    {
        _container.SetActive(false);
    }

    public void PrepareVideo(VideoClip videoClip)
    {
        _videoPlayer.Stop();
        _videoPlayer.clip = videoClip;
        _videoPlayer.Prepare();
    }

    private void PlayVideo(VideoPlayer source)
    {
        _container.SetActive(true);
        PlayPause(true);
    }

    private void LateUpdate()
    {
        UpdatePlayback();
    }

    private void UpdatePlayback()
    {        
        if(_videoPlayer.clip == null || !_videoPlayer.isPlaying)
        {
            return;
        }

        _slider.SetValueWithoutNotify((float)_videoPlayer.time / (float)_videoPlayer.clip.length);
    }

    public void SwitchPlayPause()
    {
        PlayPause(!_videoPlayer.isPlaying);
    }

    private void PlayPause(bool play)
    {
        if (play)
        {
            _videoPlayer.Play();
            _playPauseButton.sprite = _pauseSprite;

        }
        else
        {
            _videoPlayer.Pause();
            _playPauseButton.sprite = _playSprite;
        }

        _playing = play;
    }

    private void ActionOnSliderValueChanged(float time)
    {
        Debug.Log(time);
        _slider.value = time;   
        _videoPlayer.time = time * (float)_videoPlayer.clip.length;
    }

    public void OnSliderPointerUp()
    {
        if(_playing)
        {
            _videoPlayer.Play();
        }
    }


    public void OnSliderPointerDown()
    {
        _videoPlayer.Pause();
    }
}
