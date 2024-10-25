<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDrop : MonoBehaviour
{
    [SerializeField] private GameObject dropPrefab;
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
            timer = Random.Range(1f, 2f);
            GenerateDrop();
        }
    }

    private void GenerateDrop()
    {
        GameObject drop = Instantiate(dropPrefab, transform.position, Quaternion.identity);
        effect.Play();
        Destroy(drop, 1.2f);
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDrop : MonoBehaviour
{
    [SerializeField] private GameObject dropPrefab;
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
            timer = Random.Range(1f, 2f);
            GenerateDrop();
        }
    }

    private void GenerateDrop()
    {
        GameObject drop = Instantiate(dropPrefab, transform.position, Quaternion.identity);
        effect.Play();
        Destroy(drop, 1.2f);
    }
}
>>>>>>> c370533cebd4cd3cbf580a37a8dd0a4fa6e374fd
