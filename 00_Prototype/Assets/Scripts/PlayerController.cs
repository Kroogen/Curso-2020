using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [UnityEngine.Range(0,10)]
    public float speedforward;
    [UnityEngine.Range(0,180)]
    public float speedTorque;
    private Rigidbody _rigidbody;
    private float verticalInput;
    private float horizontalInput;
    public bool usePhysicsEngine;
    private int bounds = 18;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        Movimiento();
        Limites();
    }

    private void getInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void Movimiento()
    {
        if (usePhysicsEngine)
        {
            _rigidbody.AddForce(Vector3.forward * Time.deltaTime * speedforward * verticalInput , ForceMode.Force);
            _rigidbody.AddTorque(Vector3.up * Time.deltaTime * speedTorque * horizontalInput , ForceMode.Force);
            /*Si se va a utilizar física
             AddForce sobre el rigidbody
             AddTorque sobre el rigidbody
             
             Si no se usarán físicas
             Traslate sobre el transform -> para mover
             Rotate sobre el transform -> para rotar
             */
        }
        else
        {

            transform.Translate(Vector3.forward * Time.deltaTime * speedforward * verticalInput);
            transform.Rotate(Vector3.up * Time.deltaTime * speedTorque * horizontalInput);
        }
    }

    private void Limites()
    {
        if (Mathf.Abs(transform.position.x) >= bounds || Mathf.Abs(transform.position.z) >= bounds)
        {
            _rigidbody.velocity = Vector3.zero;
            if (transform.position.x > bounds)
            {
                transform.position = new Vector3(bounds, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -bounds)
            {
                transform.position = new Vector3(-bounds, transform.position.y, transform.position.z);
            }
            if (transform.position.z > bounds)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, bounds);
            }
            if (transform.position.z < -bounds)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -bounds);
            }
        }
    }

}
