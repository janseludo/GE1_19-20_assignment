using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phyllotaxis : MonoBehaviour
{
    public float _degree, _scale;
    public int _numberStart;
    public int _stepSize;
    public int _maxIntegration;

    //Learping
    public bool _useLearping;
    public float _intervalLerp;
    private bool _isLearping;

    private Vector3 _startPosition, _endPosition;
    private float _timeStartedLearping;

    private int _number;
    private int _currentIteration;
    private TrailRenderer _trailRenderer;
    private Vector2 CalculatePhyllotaxis(float degree, float scale, int number)
    {
        double angle = number * (degree * Mathf.Deg2Rad);

        float r = scale * Mathf.Sqrt(number);

        //declaring x and y radius
        float x = r * (float)System.Math.Cos(angle);
        float y = r * (float)System.Math.Sin(angle);

        Vector2 vec2 = new Vector2(x, y);

        return vec2;
    }

    private Vector2 _phyllotaxisPosition;

    void StartLearping()
    {
        _isLearping = true;
        _timeStartedLearping = Time.time;
        _phyllotaxisPosition = CalculatePhyllotaxis(_degree, _scale, _number);
        _startPosition = this.transform.localPosition;
        _endPosition = new Vector3(_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);
    }
  
    // Use this for initialization
    void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _number = _numberStart;
        transform.localPosition = CalculatePhyllotaxis(_degree, _scale, _number);
        if(_useLearping)
        {
            StartLearping();
        }

    }

    private void FixedUpdate()
    {
        if (_useLearping)
        {
            if(_isLearping)
            {
                float timeSinceStarted = Time.time - _timeStartedLearping;
                float percentageComplete = timeSinceStarted / _intervalLerp;
                transform.localPosition = Vector3.Lerp(_startPosition, _endPosition, percentageComplete);

                if (percentageComplete >= 0.97f)
                {
                    transform.localPosition = _endPosition;
                    _number += _stepSize;
                    _currentIteration++;
                    if(_currentIteration <= _maxIntegration)
                    {
                        StartLearping();
                    }
                    else
                    {
                        _isLearping = false;
                    }
                }

            }
            
        }
        else
        {
            _phyllotaxisPosition = CalculatePhyllotaxis(_degree, _scale, _number);
            transform.localPosition = new Vector3(_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);
            _number+= _stepSize;
            _currentIteration++;
        }
    }
}