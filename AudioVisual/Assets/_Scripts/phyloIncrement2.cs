using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phyloIncrement2 : MonoBehaviour
{

    public GameObject _object;        //instantiate a game object
    private float _degree = 41;       // degree
    private float _scale = 5f;        //scale
    private int _posiiton = 1;        //number
    private float _dotScale = 0;      //scale of the gameobject

    //plot the points using phyllotaxis algorithm 
    private Vector2 CalculatePhyllotaxis(float degree, float scale, int count)
    {
        double angle = count * (degree * Mathf.Deg2Rad);//convert degrees to radius
        float r = scale * Mathf.Sqrt(count);            //declare the radius
        float x = r * (float)System.Math.Cos(angle);    //declaring x radius
        float y = r * (float)System.Math.Sin(angle);    //declaring y radius
        Vector2 vec2 = new Vector2(x, y);               //retrun as vector 2 that contains the x and y value
        return vec2;
    }
    //assign the phyllotaxis position
    private Vector2 _phyllotaxisPosition;

    private void Start()
    {

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
