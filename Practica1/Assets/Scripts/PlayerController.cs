//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0,20), SerializeField, Tooltip("Velocidad del vehículo")]
    private float speed = 15;
    
    [SerializeField]
    private float turnSpeed = 50;

    public float horizontalInpuit;
    public float VerticalInpuit;
    // Update is called once per frame
    void Update()
    {
        horizontalInpuit = Input.GetAxis("Horizontal");
        VerticalInpuit = Input.GetAxis("Vertical");
        
        transform.Translate(speed*Time.deltaTime*Vector3.forward*VerticalInpuit);
        if (VerticalInpuit > 0.5 || VerticalInpuit < -0.5)
        {
            transform.Rotate(turnSpeed*Time.deltaTime*Vector3.up*horizontalInpuit);
        }
        
        
    }
}
