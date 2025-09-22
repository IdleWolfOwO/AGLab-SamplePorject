using UnityEngine;

public class Class4_answer : MonoBehaviour
{
    private GameObject Sphere;
    // 添加 Rigidbody 属性
    private Rigidbody Sphere_rb;

    public float MoveAccel = 5f;        // 移动加速度
    public float MoveMaxSpeed = 30f;    // 移动最大速度

    public float JumpStartSpeed = 5f;   // 跳跃起始速度

    private void Awake()
    {
        Sphere = this.gameObject;
        Sphere_rb = Sphere.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            // 跳跃 => 施加一个向上（Y轴正方向）的速度
            Sphere_rb.velocity = new Vector3(Sphere_rb.velocity.x, JumpStartSpeed, Sphere_rb.velocity.z);
        }
        else
        {
            Sphere_rb.AddForce(new Vector3(hori, 0, vert).normalized * MoveAccel * Sphere_rb.mass);
            // 限制最大速度大小
            // xz 平面速度单独处理
            var XZvelocity = new Vector3(Sphere_rb.velocity.x, 0, Sphere_rb.velocity.z);
            XZvelocity = XZvelocity.normalized * Mathf.Min(XZvelocity.magnitude, MoveMaxSpeed);
            // xz 轴速度限制完成再将 y轴速度加上
            Sphere_rb.velocity = new Vector3(XZvelocity.x, Sphere_rb.velocity.y, XZvelocity.z);
        }
    }
}
