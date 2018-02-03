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

    }
}