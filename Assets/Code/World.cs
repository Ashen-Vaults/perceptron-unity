using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour 
{

    [SerializeField]
    Perceptron _perceptron;

    [SerializeField]
    List<float> _inputs;

    void Awake()
    {
        _perceptron = new Perceptron(2);
        Debug.Log(_perceptron.Guess(_inputs));
    }   


}
 