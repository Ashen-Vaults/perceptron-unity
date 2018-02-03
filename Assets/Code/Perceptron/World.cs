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

        public Line targetLine;

        Dictionary<Vector3,Color> points = new Dictionary<Vector3,Color>();


        void Awake()
        {
            _perceptron = new Perceptron(2);   
        }  


        void Start()
        {
            DrawLines();
            StartCoroutine(CreatePoints( _simDuration, x => 
            { 
                StartCoroutine(AnimateSimulation(_simDuration));
            }));    
        }


        [ContextMenu("Draw Line")]
        void DrawLines()
        {
            //TODO change so not all lines are drawn at same pos
            _lines.ForEach(l => l.DrawLine( LineDispatch.lineCoordinates["bottom_left"](), LineDispatch.lineCoordinates["top_right"]() ));

            DrawPoints(() => { return _lines.FirstOrDefault(l => l.data._type == "Target");});
        }


        void DrawPoints( Func<Line> onGetTarget )
        {
            targetLine = onGetTarget();

            if(targetLine != null)
            {
                for (int i = 0; i < _pointCount; i++)
                {
                    _points.Add( new Point(targetLine.data.MapLine, targetLine.data));   
                }
            }
        }


            /// TODO: Perhaps move this out of world
        /// Instantiates points in world space
        ///
        IEnumerator CreatePoints(float duration, Action<float> onComplete)
        {
            for (int i = 0; i < _points.Count; i++)
            { 
                _points[i].Create
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


        #region Debugging

        [ContextMenu("Create Points")]
        void DebugPoints()
        {
            points.Clear();
            points.Add (LineDispatch.lineCoordinates["bottom_right"](), Color.red);
            points.Add (LineDispatch.lineCoordinates["bottom_left"](), Color.blue);
            points.Add (LineDispatch.lineCoordinates["top_left"](), Color.yellow);
            points.Add (LineDispatch.lineCoordinates["top_right"](), Color.green);
            points.Add (LineDispatch.lineCoordinates["center"](), Color.blue);
        }


        private void OnDrawGizmos() 
        {

            if(points != null)
            {
                foreach(KeyValuePair<Vector3,Color> point in points)
                {
                    Gizmos.color = point.Value;

                    Gizmos.DrawSphere(point.Key, 1);  
                }
            }
        }

        #endregion

    } 
}