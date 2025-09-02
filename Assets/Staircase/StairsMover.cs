using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsMover : MonoBehaviour
{
    [SerializeField] private Transform player;

    private DetectCurrentFloor detectCurrentFloor;
    private Spawner spawner;

    private void Start()
    {
        spawner = GetComponent<Spawner>();
        detectCurrentFloor = player.GetComponent<DetectCurrentFloor>();
    }

    private void Update()
    {
        MoveStairs();
    }

    private void MoveStairs()
    {
        if (detectCurrentFloor.Moving)
        {
            if (detectCurrentFloor.CurrentFloorIndex < spawner.MiddleFloor)
            {
                int lastIndex = spawner.objectPool.Count - 1;
                for (int i = lastIndex; i > 0; i--)
                {
                    GameObject dummy = spawner.objectPool[i];
                    spawner.objectPool[i].transform.position = spawner.objectPool[i-1].transform.position;
                    spawner.objectPool[i-1].transform.position = dummy.transform.position;
                    spawner.objectPool[i] = spawner.objectPool[i-1];
                    spawner.objectPool[i-1] = dummy;
                }
                spawner.objectPool[0].transform.position = spawner.objectPool[0].transform.position - spawner.YPosOffset;
            }

            if (detectCurrentFloor.CurrentFloorIndex > spawner.MiddleFloor)
            {
                int lastIndex = spawner.objectPool.Count - 1;
                for (int i = 0; i < lastIndex; i++)
                {
                    GameObject dummy = spawner.objectPool[i];
                    spawner.objectPool[i].transform.position = spawner.objectPool[i+1].transform.position;
                    spawner.objectPool[i+1].transform.position = dummy.transform.position;
                    spawner.objectPool[i] = spawner.objectPool[i+1];
                    spawner.objectPool[i+1] = dummy;
                }
                spawner.objectPool[lastIndex].transform.position = spawner.objectPool[lastIndex].transform.position + spawner.YPosOffset;
            }
        }
    }
}