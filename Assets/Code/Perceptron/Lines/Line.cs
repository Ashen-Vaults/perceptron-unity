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

            if(data == null)
            {
                data = new LineData();

            }

            data.SetType("Target");
        }
        
        public void DrawLine(Vector3 pointA, Vector3 pointB)
        {

            //pointA = new Vector3( -1, data.MapLine(-1), 0 );
            //pointB = new Vector3( 1, data.MapLine(1), 0 );

            _view.SetPosition(0, pointA);
            _view.SetPosition(1, pointB);

            data.positions.Add(pointA);
            data.positions.Add(pointB);
        }

    }   
}


 