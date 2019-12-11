using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVizual : MonoBehaviour
{
    public float scale = 5;
    public float scale2 = 10;
    List<GameObject> elements = new List<GameObject>();
    List<GameObject> elements2 = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateVisualiser();
    }

    public float radius = 50;
    public float radius2 = 10;

    void CreateVisualiser()
    {
        
        float theta = (Mathf.PI * 2.0f) / (float)AudioAnalyzer.bands.Length;
        for(int i = 0; i < AudioAnalyzer.bands.Length; i++)
        {
            Vector3 p = new Vector3(Mathf.Sin(theta * i)* radius, 0, Mathf.Cos(theta * i) * radius);
            p = transform.TransformPoint(p);
            Quaternion q = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up);
            q = transform.rotation * q;
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetPositionAndRotation(p, q);
            cube.transform.parent = this.transform;
            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB( i / (float)AudioAnalyzer.bands.Length, 1,1);
            elements.Add(cube);
        }
        
        float theta2 = (Mathf.PI * 2.0f) / (float)AudioAnalyzer.frameSize;
        for (int i = 0; i < AudioAnalyzer.frameSize; i++)
        {
            Vector3 p2 = new Vector3(Mathf.Sin(theta2 * i) * radius2, 0, Mathf.Cos(theta2 * i) * radius2);
            p2 = transform.TransformPoint(p2);
            Quaternion q2 = Quaternion.AngleAxis(theta2 * i * Mathf.Rad2Deg, Vector3.up);
            q2 = transform.rotation * q2;
            GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube2.transform.SetPositionAndRotation(p2, q2);
            cube2.transform.parent = this.transform;
            cube2.GetComponent<Renderer>().material.color = Color.HSVToRGB(i / (float)AudioAnalyzer.frameSize, 1, 1);
            elements2.Add(cube2);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < elements.Count; i++)
        {
            Vector3 ls = elements[i].transform.localScale;
            ls.y = Mathf.Lerp(ls.y, 1 + (AudioAnalyzer.bands[i] * scale), Time.deltaTime * 3.0f);
            elements[i].transform.localScale = ls;

            

        }
        
        
        for(int i = 0; i < elements2.Count; i++)
        {
            elements2[i].transform.localScale = new Vector3(1, 1 + AudioAnalyzer.spectrum[i] * scale2, 1);
        }
        
    }
}
