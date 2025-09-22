using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class3_CubeController : MonoBehaviour
{
    public float MoveSpeed = 5f; // 移动速度
    public float DashDist = 2f; // 冲刺距离

    private GameObject Cube;

    private void Awake()
    {
        Cube = this.gameObject;
    }


    // 为什么这里用的是 Time.deltaTime 而 Class2 用的是 Time.fixedDeltaTime 呢？[仅作了解]
    // 因为这里是在 Update （每一渲染帧）中调用，Time.deltaTime 获取的是渲染帧的间隔
    // Class2 的脚本是在 FixedUpdate（每一物理帧）中调用，Time.fixedDeltaTime 获取的是物理帧间隔
    // 获取输入一般在 Update，物理控制一般在 FixedUpdate
    void Update()
    {
        // 获取 水平 轴的输入
        float hori = Input.GetAxis("Horizontal");
        // 获取 垂直 轴的输入
        float vert = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 向移动方向冲刺
            Cube.transform.position += new Vector3(hori, vert, 0).normalized * DashDist;
        }
        else
        {
            // 正常移动
            Cube.transform.position += new Vector3(hori, vert, 0).normalized * MoveSpeed * Time.deltaTime;
            // 这里使用 .normalized 归一化是为了保证向各个方向移动速率一致
        }
    }
}