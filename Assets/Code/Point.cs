using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{

    [SerializeField]
    Vector3 _position;

    [SerializeField]
    int _label;

    public Point()
    {
        _position = new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height),0);
        _label = CalculateLabel(_position);   
    }

    int CalculateLabel(Vector3 size)
    {
        if(size.x > size.y)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }


    ///TODO: visualize
    public void Display()
    {
        /*
          if label == 1
            white
        else
            black  
         */
    }

}
 