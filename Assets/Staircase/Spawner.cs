using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject stairs;
    [SerializeField] public List<GameObject> objectPool = new List<GameObject>();

    private Vector3 startPos;

    private int middleFloor;
    public int MiddleFloor { get { return middleFloor; } }

    private Vector3 yPosOffset = new Vector3(0f, 2.875f, 0f);
    public Vector3 YPosOffset { get { return yPosOffset; } }

    private void Start()
    {
        CreateStairs();
        SetStairNames();
        FindMiddleIndex();
    }

    private void Update()
    {
        FindMiddleIndex();
    }

    private void CreateStairs()
    {
        GameObject Stairs1 = Instantiate(stairs, startPos + (-2 * yPosOffset), Quaternion.identity);
        GameObject Stairs2 = Instantiate(stairs, startPos + (-1 * yPosOffset), Quaternion.identity);
        GameObject Stairs3 = Instantiate(stairs, startPos + (0 * yPosOffset), Quaternion.identity);
        GameObject Stairs4 = Instantiate(stairs, startPos + (1 * yPosOffset), Quaternion.identity);
        GameObject Stairs5 = Instantiate(stairs, startPos + (2 * yPosOffset), Quaternion.identity);

        objectPool[0] = Stairs1;
        objectPool[1] = Stairs2;
        objectPool[2] = Stairs3;
        objectPool[3] = Stairs4;
        objectPool[4] = Stairs5;

        foreach (GameObject child in objectPool)
        {
            child.transform.SetParent(gameObject.transform);
        }
    }

    private void SetStairNames()
    {
        objectPool[0].transform.name = "Stairs1";
        objectPool[1].transform.name = "Stairs2";
        objectPool[2].transform.name = "Stairs3";
        objectPool[3].transform.name = "Stairs4";
        objectPool[4].transform.name = "Stairs5";
    }

    private void FindMiddleIndex()
    {
        middleFloor = objectPool.Count/2;
    }
}
