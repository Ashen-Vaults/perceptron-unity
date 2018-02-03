using System;
using System.Collections;
using System.Collections.Generic;
using AshenCode.Extensions;
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

        public Func<float, float> calculateLine;

        public int Label
        {
            get{ return _label; }
        }


        public Point(Func<float,float> onCalculateLine, LineData line)
        {

            calculateLine = onCalculateLine;

            _position = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Random.Range(0,Screen.width), UnityEngine.Random.Range(0,Screen.height), Camera.main.farClipPlane/2));

            //_position = new Vector3( UnityEngine.Random.Range(-1,1), UnityEngine.Random.Range(-1,1), 0 );

            _label = CalculateLabel(_position, line); 
        }

        int CalculateLabel(Vector3 size, LineData line)
        {
            return line.Dot(size);
        }
  
        public void Create(Func<GameObject> prefab, Transform parent)
        {
            if(_body == null)
            {
                _body = prefab();
            }
            _body.transform.SetParent(parent);

            //    Debug.Log(2.Remap(1, 3, 0, 10));    // 5

            //float px = _position.x.Map(-1,1,0,Screen.width);
            //float py = _position.y.Map(-1,1,Screen.height, 0);
            

            //_body.transform.localPosition = new Vector2(px,py);

            _body.transform.localPosition = _position;
            
            Display();
        }

        ///TODO: visualize
        public void Display()
        {
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
 