using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 [Serializable]
public class Point
{

    [SerializeField]
    Vector3 _position;

    [SerializeField]
    int _label;

    public int Label
    {
        get{ return CalculateLabel(_position); }
    }

    public Point()
    {
        _position = new Vector3(UnityEngine.Random.Range(0,Screen.width), UnityEngine.Random.Range(0,Screen.height),0);
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
    public void Display(Func<GameObject> prefab, Transform parent)
    {

        GameObject sphere = prefab();
        sphere.transform.SetParent(parent);
        sphere.transform.localPosition = _position;
           
        /*
          if label == 1
            white
        else
            black  
         */
    }

}
 