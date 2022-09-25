using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpawner2 : MonoBehaviour
{

    public GameObject spear;
    [SerializeField] private float cooldown;
    [SerializeField] private Vector3[] spawnPositionsArray;
    [SerializeField] private bool[] spawnTaken;
    [SerializeField] public Dictionary<Vector3, bool> spawnPositions;
    [SerializeField] private float timer;


    // Start is called before the first frame update
    void Start()
    {
        spawnPositions = new Dictionary<Vector3, bool>();
        for(int i = 0; i < spawnPositionsArray.Length; i++)
        {
            spawnPositions.Add(spawnPositionsArray[i], spawnTaken[i]);
        }

        foreach (var pair in spawnPositions)
        {
            if (!pair.Value)
            {
                GameObject spawnedSpear = Instantiate(spear, pair.Key, new Quaternion(0f, 0f, 0f, 1f)) as GameObject;
                spawnedSpear.transform.LookAt(new Vector3(0f, 0f, 0f));
                spawnedSpear.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
