using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public void DestroyCar()
    {
        Destroy(GameObject.FindGameObjectWithTag("Car"));
    }

    public void DestroyMan()
    {
        Destroy(GameObject.FindGameObjectWithTag("Man"));
    }
}
