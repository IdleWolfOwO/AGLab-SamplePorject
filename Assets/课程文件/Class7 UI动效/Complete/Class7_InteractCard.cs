using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Class7_InteractCard : MonoBehaviour, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    // 选中事件注册接口
    public UnityEvent<bool> OnSelectEvent;

    public void OnDrag(PointerEventData eventData)
    {
        // 实现卡牌跟随鼠标
        transform.position = Input.mousePosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 鼠标进入时触发选中事件
        OnSelectEvent?.Invoke(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 鼠标离开时触发选中事件
        OnSelectEvent?.Invoke(false);
    }
}
