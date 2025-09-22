using UnityEngine;

public class Class4_SphereController : MonoBehaviour
{
    private GameObject Sphere;
    // 添加 Rigidbody 属性
    private Rigidbody Sphere_rb;

    public float MoveAccel = 5f; // 移动加速度
    public float MoveMaxSpeed = 30f; // 移动最大速度

    public float DashDist = 2f; // 冲刺距离

    private void Awake()
    {
        Sphere = this.gameObject;
        // 添加获取 Rigidbody 的逻辑
        Sphere_rb = Sphere.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // GetAxisRaw   无惯性，即按即停
        // GetAxis      有惯性，需等待回弹
        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            // TODO：冲刺
        }
        else
        {
            // 力大小 = 移动方向 * 移动加速度 * 物体质量
            Sphere_rb.AddForce(new Vector3(hori, 0, vert).normalized * MoveAccel * Sphere_rb.mass);
            // 限制最大速度大小
            // 速度 = 速度方向 * Min(原来速度大小， 最大速度大小)
            Sphere_rb.velocity = Sphere_rb.velocity.normalized * Mathf.Min(Sphere_rb.velocity.magnitude, MoveMaxSpeed);
        }
    }
}
