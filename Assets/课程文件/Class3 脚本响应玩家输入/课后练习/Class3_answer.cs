using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class3_answer : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float DashDist = 2f;
    public float DashGap = 3f;  // 冲刺间隔

    // 存储上次冲刺的时间
    private float lastDashTime = 0;

    private GameObject Cube;

    private void Awake()
    {
        Cube = this.gameObject;
    }


    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");


        // if (Input.GetKeyDown(KeyCode.Space))
        // 更改冲刺的触发为 LeftShift 键 && 当前时间 > 上次冲刺时间 + 冲刺间隔
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > lastDashTime + DashGap)
        {
            Cube.transform.position += new Vector3(hori, vert, 0).normalized * DashDist;
            // 成功冲刺后才更新 lastDashTime
            lastDashTime = Time.time;
        }
        else
        {
            Cube.transform.position += new Vector3(hori, vert, 0).normalized * MoveSpeed * Time.deltaTime;
        }
    }
}
