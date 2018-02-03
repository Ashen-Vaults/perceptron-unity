using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AshenCode.NeuralNetworks.Perceptron
{
    public static class LineDispatch  
    {

        public static Dictionary<string,Func<Vector3>> lineCoordinates = new  Dictionary<string,Func<Vector3>>()
        {
            { "bottom_left", ()=> { return Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane/2)); }},
            { "bottom_right", ()=> { return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.farClipPlane/2)); }},

            { "top_left", ()=> { return Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.farClipPlane/2)); }},
            { "top_right", ()=> { return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane/2)); }},

            { "center", ()=> { return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, Camera.main.farClipPlane/2)); }}
        };
    }
}
 