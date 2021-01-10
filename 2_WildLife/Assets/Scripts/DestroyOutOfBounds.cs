using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{


    public int LimiteSuperior = 30;
    public int LimiteInferior = -15;

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z > LimiteSuperior)
        {
            Destroy(this.gameObject);
        }

        if (this.transform.position.z < LimiteInferior)
        {
            Debug.Log("G A M E   O V E R ! ! !");
            Destroy(this.gameObject);
            Time.timeScale = 0;
        }
    }
}
