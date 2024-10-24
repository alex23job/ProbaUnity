using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControl : MonoBehaviour
{
    [SerializeField] private AudioSource effect;
    [SerializeField] private List<Vector3> points;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float piskDelay = 2f;
    [SerializeField] private AudioClip pisk;
    [SerializeField] private AudioClip wing;
    
    private Animator anim;
    private Vector3 target;
    private int index = 0;
    private bool isFlight = false;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        target = points[index];
        timer = piskDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlight)
        {
            if (transform.position != target)
            {
                Vector3 delta = target - transform.position;
                transform.rotation = Quaternion.LookRotation(delta.normalized);
                if (delta.magnitude > 0.05)
                {
                    Vector3 movement = delta.normalized * Time.deltaTime * speed;
                    if (movement.magnitude < delta.magnitude) transform.position += movement;
                    else transform.position = target;
                }
                else transform.position = target;
            }
            else
            {
                index++;
                index %= points.Count;
                target = points[index];
            }
        }
        else
        {
            if (timer > 0) timer -= Time.deltaTime;
            else
            {
                timer = piskDelay;
                effect.clip = pisk;
                effect.Play();
            }
        }
    }

    public void ChangeFlight(bool zn)
    {
        isFlight = zn;
        if (effect != null)
        {
            if (isFlight)
            {
                effect.clip = wing;
                effect.Play();
            }
            else effect.Stop();
        }
        if (anim != null)
        {
            anim.SetBool("isFlight", isFlight);
        }
    }
}
