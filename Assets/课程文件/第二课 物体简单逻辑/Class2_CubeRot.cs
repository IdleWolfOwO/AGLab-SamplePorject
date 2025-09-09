using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class2_CubeRot : MonoBehaviour
{
    private GameObject Cube;
    private void Awake()
    {
        Cube = this.gameObject;
    }
    void Update()
    {
        Cube.transform.eulerAngles += new Vector3(0, 20f, 0) * Time.deltaTime;
    }
}
