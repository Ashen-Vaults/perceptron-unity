using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AshenCode.NeuralNetworks.Perceptron
{
    [Serializable]
    public class Point
    {

        [SerializeField]
        Vector3 _position;

        [SerializeField]
        int _label;

        GameObject _body;

        public int Label
        {
            get{ return CalculateLabel(_position); }
        }


        public Point()
        {
            _position = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Random.Range(0,Screen.width), UnityEngine.Random.Range(0,Screen.height), Camera.main.farClipPlane/2));

            _label = CalculateLabel(_position); 
        }

        int CalculateLabel(Vector3 size)
        {
            if(size.x > size.y)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        ///TODO: visualize
        public void Display(Func<GameObject> prefab, Transform parent)
        {
            if(_body == null)
            {
                _body = prefab();
            }
            _body.transform.SetParent(parent);
            _body.transform.localPosition = _position;

            if(_label == 1)
            {
                SetColor(Color.white);
            }
            else
            {
                SetColor(Color.black);
            }
        }

        public void Compare(int guess)
        {
            if(guess == _label)
            {
                SetColor(Color.green);
            }
            else
            {
                SetColor(Color.red);
            }
        }

        public void SetColor(Color color)
        {
            if(_body != null)
            {
                Renderer render = _body.GetComponent<Renderer>();
                if(render != null)  
                {
                    render.material.color = color;
                }
            }
        }
    }
}
 