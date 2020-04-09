using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObject : MonoBehaviour
{
    public bool detectObject(Vector3 checkCoord,float radius)
    {
        Collider[] intersects = Physics.OverlapSphere(checkCoord, radius); //Gets list of objects in area
        if (intersects.Length > 0) //If there is an item in the list of objects in the area
                                   //the function will return true
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
