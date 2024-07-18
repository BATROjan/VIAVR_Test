using RenderHeads.Media.AVProVideo;
using UnityEngine;

namespace Video
{
    public class VideoController
    {
        private readonly MediaPlayer _mediaPlayer;
        private readonly VideoView _videoView;

        private bool isPLaying;
        private MediaReference currentMediaReference;
        public VideoController(
            MediaPlayer mediaPlayer,
            VideoView videoView)
        {
            _mediaPlayer = mediaPlayer;
            _videoView = videoView;
            
            _videoView.playPauseButton.OnClick += VideoControle;
            _mediaPlayer.Events.AddListener(HandleEvent);
        }
        public void ChangeVideo(MediaReference mediaReference)
        {
            if (currentMediaReference != mediaReference)
            {
                currentMediaReference = mediaReference;
                _mediaPlayer.OpenMedia(mediaReference, autoPlay:false);
                isPLaying = false;
                _videoView.playPauseButtonImage.sprite = _videoView.playImage;
            }
        }

        public void SetStartVideo(VideoConfig videoConfig)
        {
            currentMediaReference = videoConfig.GetAllModels()[0].MediaReference;
            _mediaPlayer.OpenMedia(currentMediaReference, autoPlay:false);;
        }

        private void VideoControle()
        {
            if (isPLaying)
            {
                _mediaPlayer.Stop();
                _videoView.playPauseButtonImage.sprite = _videoView.playImage;
                Debug.Log("Pause");
            }
            else
            {
                _mediaPlayer.Play();
                _videoView.playPauseButtonImage.sprite = _videoView.pauseImage;
                Debug.Log("PLay");
            }
            isPLaying = !isPLaying;
        }
        
        void HandleEvent(MediaPlayer mp, MediaPlayerEvent.EventType eventType, ErrorCode code)
        {
            if (eventType == MediaPlayerEvent.EventType.FinishedPlaying)
            {
                VideoControle();
            }
        }
    }
}