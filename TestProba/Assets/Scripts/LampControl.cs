using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampControl : MonoBehaviour
{
    private Light light;
    private bool isLight = false;
    // Start is called before the first frame update
    void Start()
    {
        light = transform.GetChild(0).GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLight)
        {
            if (light.intensity < 1f) light.intensity += Time.deltaTime;
        }
    }

    public void SetLight()
    {
        isLight = true;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
        light.intensity = 0;
    }
}
