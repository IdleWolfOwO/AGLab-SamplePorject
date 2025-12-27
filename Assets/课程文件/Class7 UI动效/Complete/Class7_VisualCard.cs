using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class7_VisualCard : MonoBehaviour
{
    [Header("当前状态")]
    public Class7_InteractCard followCard;
    public Vector3 followMoveSpeed;
    public Vector3 followRotSpeed;

    [Space(20)]
    [Header("跟随预设")]
    public float MoveMaxSpeed = 10000f;
    public float MoveSmoothTime = 0.05f;
    public float RotSclae = 0.2f;

    private void Awake()
    {
        followCard.OnSelectEvent.AddListener(OnSelect);
    }

    private void Update()
    {
        if (followCard != null)
        {
            // 平滑跟随
            transform.position = Vector3.SmoothDamp(transform.position, followCard.transform.position, ref followMoveSpeed, MoveSmoothTime, MoveMaxSpeed);

            // 根据与 followCard 左右相隔的距离旋转
            Vector3 targetRot = new Vector3();
            targetRot.x = followCard.transform.eulerAngles.x;
            targetRot.y = followCard.transform.eulerAngles.y;
            targetRot.z = followCard.transform.eulerAngles.z + (transform.position.x - followCard.transform.position.x) * RotSclae;
            transform.eulerAngles = targetRot;
        }
    }

    public void OnSelect(bool _isSelected)
    {
        // 选中 & 取消 选中卡牌晃动
        transform.DOShakeRotation(0.05f, 20, 10, 40).SetLink(gameObject);

        if (_isSelected)
        {
            // 选中时放大自身
            transform.DOScale(1.07f, 0.2f).SetLink(gameObject);
        }
        else
        {
            // 取消选中时还原自身
            transform.DOScale(1f, 0.2f).SetLink(gameObject);
        }
    }
}
