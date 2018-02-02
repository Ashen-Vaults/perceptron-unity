using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

    * For every input, multiply that input by its weight.

    * Sum all of the weighted inputs.
    
    * Compute the output of the perceptron based on the sum pass thru an
      activation function (the sign of the sum)

 */
 [Serializable]
public class Perceptron 
{
    [SerializeField]
    List<float> _weights = new List<float>();

    public Perceptron(int weightSize)
    {
        //Initialize the weights
        for (int i=0; i < weightSize; i++)
        {
            _weights.Add(UnityEngine.Random.Range(-1,1));
        }
    }

    public int Guess(List<float> inputs)
    {
        float sum = 0;
        for (int i = 0; i < _weights.Count; i++)
        {
            sum += inputs[i] * _weights[i];   
        }
        return Math.Sign(sum);
    }

}
 