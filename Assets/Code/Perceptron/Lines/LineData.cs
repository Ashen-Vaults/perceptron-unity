using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AshenCode.NeuralNetworks.Perceptron
{

    [Serializable]
    public class LineData
    {
        public string _type;
        public float start, end;
        public List<Vector3> positions;


        public void SetType(string type)
        {
            _type = type;      
        }


        public float MapLine(float x)
        {
            return start * x + end;
        }


        public Vector3 GetStartPoint()
        {
            return positions[0];
        }


        public Vector3 GetEndPoint()
        {
            return positions[positions.Count-1];    
        }


        public int GetSide(Vector3 point)
        {
            Vector3 diff = GetEndPoint() - GetStartPoint();
            Vector3 perp = new Vector3(-diff.y, diff.x,0);
            float d = Vector3.Dot(point - GetStartPoint(), perp);
            return Math.Sign(d);
        }

    }
}