using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class4 : MonoBehaviour
{
    private GameObject Cube;
    private Rigidbody  Cube_rb;

    private void Awake()
    {
        Cube = this.gameObject;
        Cube_rb = Cube.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Cube.transform.position.y < -10)
        {
            Cube.transform.position = new Vector3(Cube.transform.position.x, 4, Cube.transform.position.z);
            Cube_rb.velocity = Vector3.zero;
        }
    }
}
