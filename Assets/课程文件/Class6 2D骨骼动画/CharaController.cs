using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        // 获取物体的 Animator[动画器组件]
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 当我检测到玩家按下 Space 的时候
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 就触发名为 onSayHello 的Trigger
            animator.SetTrigger("onSayHello");
        }
    }
}
