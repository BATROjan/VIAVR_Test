using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Video;

namespace DefaultNamespace
{
    public class UIButton: MonoBehaviour, IPointerClickHandler
    {
        public Action OnClick;
        public Action<VideoPreView> OnChangeContent;
        public Action<VideoPreView> OnChangeVideo;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
            OnChangeContent?.Invoke(GetComponent<VideoPreView>());
        }
    }
}