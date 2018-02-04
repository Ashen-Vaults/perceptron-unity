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


        public Perceptron(int weightSize)
        {
            //Initialize the weights
            for (int i=0; i < weightSize; i++)
            {
                _inputs.Add(new Input()
                {
                    value = 0.5f,
                    weight = UnityEngine.Random.Range(-1,1)
                });
            }
        }


        public int Guess(List<float> inputs)
        {
            float sum = 0;
            for (int i = 0; i < _inputs.Count; i++)
            {
                sum += _inputs[i].Product();  
            }
            return Math.Sign(sum);
        }

        public int Guess()
        {
            List<float> values = this._inputs.Select( i => i.value).ToList();
            return Guess(values);
        }

        
        ///
        /// Given a series of inputs, 
        /// attempt a guess, get the std error
        /// adjust the weights 
        ///
        public void Train(List<float> inputs, int target)
        {
            int guess = Guess(inputs);
            int error = target - guess;
            _inputs.ForEach( i => i.ModifyWeight(x => {return x += error * i.value * _learningRate;}));
        }


        public void Train(int target)
        {
            List<float> values = this._inputs.Select( i => i.value).ToList();
            Train(values, target);
        }

    }
}