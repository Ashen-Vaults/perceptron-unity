using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AshenCode.NeuralNetworks.Perceptron
{
    public class Line : MonoBehaviour 
    {
        [SerializeField]
        LineRenderer _view;

        [SerializeField]
        public LineData data;

        void Awake()
        {
            if(_view == null)
            {
                _view = this.GetComponent<LineRenderer>();
            }
        }

        public void DrawLine(Vector3 pointA, Vector3 pointB)
        {
            _view.SetPosition(0, pointA);
            _view.SetPosition(1, pointB);
        }

    }   
}


 