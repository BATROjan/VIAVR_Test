using System;
using RenderHeads.Media.AVProVideo;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Video
{
    [CreateAssetMenu(fileName = "VideoConfig", menuName = "Configs/VideoConfig")]
    public class VideoConfig : ScriptableObject
    {
        [SerializeField] private VideoModel[] videoModels;
        
        public VideoModel GetVideoModel(string name)
        {
            VideoModel currentModel = new VideoModel();
            foreach (var videoModel in videoModels)
            {
                if (name == videoModel.Name)
                {
                    currentModel = videoModel;
                }
            }
            return currentModel;
        }

        public VideoModel[] GetAllModels()
        {
            return videoModels;
        }
    }

    [Serializable]
    public struct VideoModel
    {
        public MediaReference MediaReference;
        public string Name;
        public Sprite PreView;
    }
}