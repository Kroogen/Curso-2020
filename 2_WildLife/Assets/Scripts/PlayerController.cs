using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Tooltip("Velocidad hacia delante")]
    private float speed = 10;

    public float HorizontalFactor;
    public float VerticalFactor;

    private int xRange = 15;
    private Vector2 yRange = new Vector2(-1, 15);

    public GameObject projectilePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalFactor = Input.GetAxis("Horizontal");
        VerticalFactor = Input.GetAxis("Vertical");

        //Movimiento
        if (HorizontalFactor < 0 && transform.position.x > -xRange || HorizontalFactor > 0 && transform.position.x < xRange) {
            transform.Translate(HorizontalFactor * speed * Time.deltaTime * Vector3.right);
        }
        if (VerticalFactor < 0 && transform.position.z > yRange.x || VerticalFactor > 0 && transform.position.z < yRange.y) {
            transform.Translate(VerticalFactor * speed * Time.deltaTime * Vector3.forward);
        }
        
        //Acciones
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(projectilePrefab, //Que se instancia
                transform.position,  //Posición donde lo hace
                projectilePrefab.transform.rotation); //Rotación que tendrá
        }
    }
}
