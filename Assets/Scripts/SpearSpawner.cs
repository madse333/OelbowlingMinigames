using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpawner : MonoBehaviour
{
    public GameObject spear;
    [SerializeField] private GameObject[] players;
    [SerializeField] private float cooldown;
    [SerializeField] private float spearPower;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float timer;

    private void Start()
    {
        timer = cooldown;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            GameObject spawnedSpear = Instantiate(spear, spawnPosition, new Quaternion(0f, 0f, 0f, 1f)) as GameObject;
            spawnedSpear.transform.LookAt(players[Random.Range(0, players.Length)].transform);
            spawnedSpear.GetComponent<Rigidbody>().AddForce((players[Random.Range(0, players.Length)].transform.position - spawnedSpear.transform.position) * spearPower);
            cooldown = Random.Range(0.5f, 2f);
            timer = cooldown;
        }
    }
}
