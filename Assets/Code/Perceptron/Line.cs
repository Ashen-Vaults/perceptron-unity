using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AshenCode.NeuralNetworks.Perceptron
{
    public class Line : MonoBehaviour 
    {
        [SerializeField]
        LineRenderer _lineView;

        void Awake()
        {
            if(_lineView == null)
            {
                _lineView = this.GetComponent<LineRenderer>();
            }
        }

        public void DrawLine(Vector3 pointA, Vector3 pointB)
        {
            _lineView.SetPosition(0, pointA);
            _lineView.SetPosition(1, pointB);
        }

    }   
}


 