using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCurrentFloor : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float searchDist = 10f;

    private Spawner spawner;
    private DeathManager deathManager;

    private float deathTimer;
    private float deathWaitTime = 2f;

    private bool moving;
    public bool Moving { get { return moving; } }

    private int currentFloorIndex;
    public int CurrentFloorIndex { get { return currentFloorIndex; } }

    private int previousFloorIndex;

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        deathManager = FindObjectOfType<DeathManager>();
    }

    private void Update()
    {
        PerformRayCast();
    }

    private void PerformRayCast()
    {
        Vector3 direction = -transform.up;
        Debug.DrawRay(transform.position, direction, Color.green);

        if (Physics.Raycast(transform.position, direction, out RaycastHit raycastHit, searchDist, groundLayer))
        {
            deathTimer = 0f;
            GameObject currentFloor = raycastHit.transform.parent.parent.gameObject;
            if (spawner.objectPool.IndexOf(currentFloor) != previousFloorIndex)
            {
                moving = true;
                currentFloorIndex = spawner.objectPool.IndexOf(currentFloor);
            }
            else
            {
                moving = false;    
            }
    
        }

        else
        {
            deathTimer += Time.deltaTime;
            if (deathTimer > deathWaitTime)
            {
                deathManager.ProccessDeath();
                deathTimer = -Mathf.Infinity;
            }
        }
    }
}
