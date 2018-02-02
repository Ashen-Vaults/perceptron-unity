using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AshenCode.NeuralNetworks.Perceptron
{

    public class World : MonoBehaviour 
    {

        [SerializeField]
        int _pointCount;

        [SerializeField]
        Perceptron _perceptron;

        [SerializeField]
        List<Point> _points;

        [SerializeField]
        List<Line> _lines;

        [SerializeField]
        List<float> _inputs;

        [SerializeField]
        GameObject _prefab;

        [SerializeField][Range(0,1)]
        float _simDuration=0.5f;

        Coroutine _simRoutine;

        void Awake()
        {
            
            for (int i = 0; i < _pointCount; i++)
            {
                _points.Add( new Point() );   
            }

            _perceptron = new Perceptron(2);
   
        }  

        void Start()
        {
            _lines.ForEach(l => l.DrawLine( LineDispatch.lineCoordinates["bottom_left"](), LineDispatch.lineCoordinates["top_right"]() ));
 
            StartCoroutine(CreatePoints( _simDuration, x => 
            { 
                StartCoroutine(AnimateSimulation(_simDuration));
            }));    
        }


            /// TODO: Perhaps move this out of world
        /// Instantiates points in world space
        ///
        IEnumerator CreatePoints(float duration, Action<float> onComplete)
        {
            for (int i = 0; i < _points.Count; i++)
            { 
                _points[i].Display
                (
                    ()=>
                    {
                        return Instantiate(_prefab);
                    }, 
                    this.transform
                );

                yield return new WaitForSeconds(duration);
            }

            if(onComplete != null)
            {
                onComplete(duration);
            }
        }


        #region Simulation

        [ContextMenu("Simulate")]
        void Simulate()
        {
            if(_simRoutine != null)
            {
                StopCoroutine(_simRoutine);
            }

            _simRoutine =  StartCoroutine(AnimateSimulation(_simDuration));

        }


        /// Trains the perceptron using
        /// input data and each points label as the target
        /// attempts a guess, then re-calculates weights
        IEnumerator AnimateSimulation(float duration=0.5f)
        {
            for (int i = 0; i < _points.Count; i++)
            { 
                _perceptron.Train(_inputs, _points[i].Label);

                int guess = _perceptron.Guess(_inputs);

                _points[i].Compare(guess);

                yield return new WaitForSeconds(duration);
            }
        }
        #endregion 
    } 
}