using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStone : MonoBehaviour
{
    [SerializeField] private float minDelta = 1f;
    [SerializeField] private float maxDelta = 2f;
    [SerializeField] private float limitRectX = 2f;
    [SerializeField] private float limitRectZ = 3f;

    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private AudioSource effect;

    private float timer = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        else
        {
            timer = Random.Range(minDelta, maxDelta);
            GenerateDrop();
        }
    }

    private void GenerateDrop()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.x += Random.Range(-limitRectX, limitRectX);
        spawnPos.z += Random.Range(-limitRectZ, limitRectZ);
        GameObject stone = Instantiate(stonePrefab, spawnPos, Quaternion.identity);
        effect.Play();
        Destroy(stone, 3f);
    }
}
