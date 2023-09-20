using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateGrid : MonoBehaviour
{
    public int gridWidth, gridHeight, gridSpacing;
    public GameObject GridSquare;
    // Start is called before the first frame update
    void Start()
    {
        GridGeneration();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GridGeneration()
    {
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                GameObject _instanceGridPoint = (GameObject)Instantiate(GridSquare);
                _instanceGridPoint.transform.position = new Vector3(i * gridSpacing, j * gridSpacing,0 );
            }
        }
    }
}
