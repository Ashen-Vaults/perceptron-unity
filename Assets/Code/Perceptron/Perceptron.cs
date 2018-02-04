using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

    * For every input, multiply that input by its weight.

    * Sum all of the weighted inputs.
    
    * Compute the output of the perceptron based on the sum pass thru an
      activation function (the sign of the sum)

 */

namespace AshenCode.NeuralNetworks.Perceptron
{
    [Serializable]
    public class Perceptron 
    {
        [SerializeField]
        List<Input> _inputs = new List<Input>();
        
        [SerializeField]
        float _learningRate = 0.001f;

        List<float> _testInputs = new List<float>()
        {
            0.5f, 1
        };


        public Perceptron(int weightSize)
        {
            //Initialize the weights
            for (int i=0; i < weightSize; i++)
            {
                _inputs.Add(new Input()
                {
                    value = _testInputs[UnityEngine.Random.Range(0,_testInputs.Count)],
                    weight = UnityEngine.Random.Range(-1,1)
                });
            }
        }


        public int Guess()
        {
            float sum = 0;
            _inputs.ForEach( i => { sum += i.Product() ;} );
            return Math.Sign(sum);
        }

        
        ///
        /// Given a series of inputs, 
        /// attempt a guess, get the std error
        /// adjust the weights 
        ///
        public void Train(int target)
        {
            int guess = Guess();
            int error = target - guess;
            _inputs.ForEach( i => i.ModifyWeight(x => {return x += error * i.value * _learningRate;}));
        }

    }
}