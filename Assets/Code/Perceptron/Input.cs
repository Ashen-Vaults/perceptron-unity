using System;
using System.Collections;
using System.Collections.Generic;


[Serializable]
public struct Input 
{
    public float value;
    public float weight;

    public float Product()
    {
        return value * weight;
    }

    public void SetWeight(Func<float,float> modifier)
    {
            weight = modifier(weight);
    }
}
 