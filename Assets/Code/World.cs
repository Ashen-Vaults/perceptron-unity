using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour 
{

    [SerializeField]
    int _pointCount;

    [SerializeField]
    Perceptron _perceptron;

    [SerializeField]
    List<Point> _points;

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

        Debug.Log(_perceptron.Guess(_inputs));
    }  


    [ContextMenu("Simulate")]
    void Start()
    {
        if(_simRoutine != null)
        {
            StopCoroutine(_simRoutine);
        }
        _simRoutine = StartCoroutine(Simulate(_simDuration));
    }


    IEnumerator Simulate(float duration=0.5f)
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
     
            _perceptron.Train(_inputs, _points[i].Label);

            int guess = _perceptron.Guess(_inputs);

            if(guess == _points[i].Label)
            {
                _points[i].SetColor(Color.green);
            }
            else
            {
                _points[i].SetColor(Color.red);
            }

            yield return null;
        }
    } 
}
 