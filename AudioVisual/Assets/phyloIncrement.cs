using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phyloIncrement : MonoBehaviour
{
   
    public GameObject _object;         //instantiate a game object
    private float _degree = 137.5f;    // degree
    private float _scale =  5f;        //scale
    private int _posiiton = 1;         //number
    private float _dotScale = 0;       //scale of the gameobject

    //plot the points using phyllotaxis algorithm 
    private Vector2 CalculatePhyllotaxis(float degree, float scale, int count)
    {
        //convert degrees to radius
        double angle = count * (degree * Mathf.Deg2Rad);
        //declare the radius
        float r = scale * Mathf.Sqrt(count);
        //declaring x and y radius
        float x = r * (float)System.Math.Cos(angle);
        float y = r * (float)System.Math.Sin(angle);
        //retrun as vector 2 that contains the x and y value
        Vector2 vec2 = new Vector2(x, y);
        return vec2;
    }
    //assign the phyllotaxis position
    private Vector2 _phyllotaxisPosition;



    private void Start(){

    }

    void Update()
    { 
            _phyllotaxisPosition = CalculatePhyllotaxis(_degree, _scale, _posiiton);
            GameObject _objectInstance = (GameObject)Instantiate(_object);
            _objectInstance.transform.position = new Vector3(_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);
            _objectInstance.transform.localScale = new Vector3(_dotScale, _dotScale, _dotScale);

            _posiiton++;
    }
}
