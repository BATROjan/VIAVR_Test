using System;
using DefaultNamespace.SelectPanel;
using RenderHeads.Media.AVProVideo;
using UnityEngine;
using Video;

namespace DefaultNamespace
{
    public class ApplicationStatupController : MonoBehaviour
    {
        [SerializeField] private SelectPanelView selectPanelView;
        [SerializeField] private MediaPlayer mediaPlayer;
        [SerializeField] private VideoView videoView;
        
        private NameTextController _textController;
        private VideoController _videoController;
        private VideoConfig _videoConfig;
        
        private SelectPanelController _selectPanelController;
        private void Start()
        {
            _videoConfig = Resources.Load<VideoConfig>("VideoConfig");
            
            _textController = new NameTextController();
            _videoController = new VideoController(mediaPlayer, videoView);
            _selectPanelController = new SelectPanelController(_videoConfig, selectPanelView,_textController,_videoController);
            
            _selectPanelController.SetUpPanel();
        }
    }
}