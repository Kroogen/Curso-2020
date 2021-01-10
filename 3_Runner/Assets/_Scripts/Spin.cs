using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speedTraslate = 6.5f;
    public float speedRotate = 60;
    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.left * speedTraslate * Time.deltaTime; 
        transform.Rotate(Vector3.up * speedRotate * Time.deltaTime);
    }
}
