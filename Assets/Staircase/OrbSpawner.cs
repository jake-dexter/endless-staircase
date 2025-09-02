using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    [SerializeField] GameObject orb;

    private List<GameObject> orbList = new List<GameObject>();

    private DetectCurrentFloor detectCurrentFloor;

    private bool pickup1Filled;
    private bool pickup2Filled;

    private void Start()
    {
        detectCurrentFloor = FindObjectOfType<DetectCurrentFloor>();   
    }

    void Update()
    {
        CheckNewOrbSpawn();
    }

    private void CheckNewOrbSpawn()
    {
        if (detectCurrentFloor.Moving)
        {
            Debug.Log($"{detectCurrentFloor.CurrentFloorIndex} Spawned new orb");
            float spawnNewOrb = Random.Range(1, 11);
            if (spawnNewOrb == 2 || spawnNewOrb == 4)
            {
                SpawnOrb("Flashlight");
            }
            if (spawnNewOrb == 3)
            {
                SpawnOrb("End");
            }
        }
    }

    private void SpawnOrb(string type)
    {
        if (type == "Flashlight")
        {

        }
        else if (type == "End")
        {

        }
    }
}