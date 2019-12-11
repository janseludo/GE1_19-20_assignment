using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorGen : MonoBehaviour
{
    public Transform prefab;
    public Vector2 floorSize;



    //
    public void GenerateFloor()
    {
        for(int x =0; x < floorSize.x; x++)
        {
            for(int y = 0; y < floorSize.y; y++)
            {
                //Vector3 prefabPosition = new Vector3(floorSize.x/2 + 1.0f + x, -1, floorSize.y + 1.0f + y);
                //Transform newFloor = Instantiate(prefab, prefabPosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                GameObject tmpGb = Instantiate(Resources.Load("prefab", typeof(GameObject))) as GameObject;
                tmpGb.transform.position = new Vector3(y* 1.5f-3 ,x * -1.5f+3, 0);
              
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateFloor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
