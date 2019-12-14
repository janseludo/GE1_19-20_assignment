using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phyloIncrement : MonoBehaviour
{
    public GameObject _object;
    public float _degree, _c;
    public int _n;
    private float _dotScale;

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

    private void Start()
    {
  
    
    }

    void Update()
    { 
            _phyllotaxisPosition = CalculatePhyllotaxis(_degree, _c, _n);
            GameObject _objectInstance = (GameObject)Instantiate(_object);
            _objectInstance.transform.position = new Vector3(_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);
            _objectInstance.transform.localScale = new Vector3(_dotScale, _dotScale, _dotScale);
            _n++;
    }
}
