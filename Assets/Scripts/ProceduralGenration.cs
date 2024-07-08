using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenration : MonoBehaviour
{
    public float incrementSize = 5f;
    public GameObject Room;
    private Vector3 initialPosition = new Vector3(0,0,0);

    private Vector3 North = new Vector3(0, 0, 1);
    private Vector3 South = new Vector3(0, 0, -1);
    private Vector3 West = new Vector3(-1, 0, 0);
    private Vector3 East = new Vector3(1, 0, 0);
    private List<Vector3> directions = new List<Vector3>();



    void Start()
    {
        directions.Add(new Vector3(0, 0, 1));
        directions.Add(new Vector3(0, 0, -1));
        directions.Add(new Vector3(-1, 0, 0));
        directions.Add(new Vector3(1, 0, 0));


        Vector3 NextPostion = initialPosition;
        for (int i = 0; i < 100; i++) {
            int direction = Random.Range(0, 4);

            NextPostion += directions[direction];
            Instantiate(Room, NextPostion * incrementSize, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
