﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOuOfBounds : MonoBehaviour
{
    private int Limite = -3;

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < Limite)
        {
            Destroy(this.gameObject);
        }
    }
}
