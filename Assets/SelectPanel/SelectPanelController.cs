using RenderHeads.Media.AVProVideo;
using Video;

namespace DefaultNamespace.SelectPanel
{
    public class SelectPanelController 
    {
        private readonly VideoConfig _videoConfig;
        private readonly SelectPanelView _selectPanelView;
        private readonly NameTextController _textController;
        private readonly VideoController _videoController;

        private VideoModel[] videoModels;
        
        public SelectPanelController(VideoConfig videoConfig,
            SelectPanelView selectPanelView,
            NameTextController textController,
            VideoController videoController)
        {
            _videoConfig = videoConfig;
            _selectPanelView = selectPanelView;
            _textController = textController;
            _videoController = videoController;
            PrepairStartVideo();
        }
        public void PrepairStartVideo()
        {
            _textController.ChangeText(_selectPanelView.SelectVieoName, _videoConfig.GetAllModels()[0].Name);
            _videoController.SetStartVideo(_videoConfig);
        }

        public void SetUpPanel()
        {
            videoModels = _videoConfig.GetAllModels();

            for (int i = 0; i < _selectPanelView._preViews.Length; i++)
            {
                _selectPanelView._preViews[i].Image.sprite = videoModels[i].PreView;
                _selectPanelView._preViews[i].Name = videoModels[i].Name;
                _selectPanelView._preViews[i].GetComponent<UIButton>().OnChangeContent += ChangeContent;
            }
        }

        private void ChangeContent(VideoPreView preView)
        {
            _textController.ChangeText(_selectPanelView.SelectVieoName, preView.Name);
            _videoController.ChangeVideo(_videoConfig.GetVideoModel(preView.Name).MediaReference); 
        }
    }
}