using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RepetBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float tamRecorrido;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        tamRecorrido = GetComponent<BoxCollider>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPos.x - transform.position.x > tamRecorrido)
        {
            transform.position = startPos;
        }
    }
}
