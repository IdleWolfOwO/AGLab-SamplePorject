using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class2_CubeRot : MonoBehaviour
{
    // 类变量，存储要转动的物体
    private GameObject Cube;


    private void Awake()
    {
        // 唤醒时获取要转动的物体
        // this.gameObject => 脚本挂载的物体
        Cube = this.gameObject;
    }


    private void FixedUpdate()
    {
        // 在每一帧旋转物体
        // Time.deltaTime => 距离上一帧经过的时间
        // 每秒旋转 * 这两帧经过多少秒（Time.deltaTime） => 这一帧要转多大
        Cube.transform.eulerAngles += new Vector3(0, 20f, 0) * Time.fixedDeltaTime;
    }
}
