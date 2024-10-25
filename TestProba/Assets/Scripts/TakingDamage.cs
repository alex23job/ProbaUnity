using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingDamage : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    [SerializeField] private int MaxHP = 100;
    [SerializeField] private LevelControl lc;
    [SerializeField] private float speedDown = 5f;
    [SerializeField] private int stoneDamage = 10;

    private bool isDown = false;
    private bool isBoard = false;
    // Start is called before the first frame update
    void Start()
    {
        if (lc != null) lc.ViewHP(HP, MaxHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (isBoard) return;
        if (isDown)
        {
            Vector3 pos = transform.position;
            pos.y -= speedDown * Time.deltaTime;
            transform.position = pos;
            if (lc != null && pos.y < -2)
            {
                lc.PlayerKilled();
            }
        }
        
    }

    public void PlayerDown()
    {
        isDown = true;
    }

    public void PlayerSetBoard()
    {
        isBoard = true;
    }

    public void ChangeHP(int delta)
    {
        int tmp = HP + delta;
        if (lc != null)
        {
            if (tmp <= 0)
            {
                lc.PlayerKilled();
            }
            else
            {
                HP = tmp;
                lc.ViewHP(HP, MaxHP);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("stone"))
        {
            ChangeHP(-stoneDamage);
        }
    }
}
