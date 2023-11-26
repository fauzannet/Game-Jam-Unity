using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class enemyspider : MonoBehaviour
{

    private int spidey = 0;
    public Transform target;
    public float jarak = 5;
    public Animator spideyanim;
    public float speed = 4;
    public float rotationSpeed = 10;
    public int HealthPoint = 10;
    private int lifeTime = 5;
    public float waittime;
    private Animator _animatorPlayer;
    public GameObject player, players, healthBars, potion;
    private Rigidbody TheRigidbody;
    public Slider healthBar;
    public float KnockbackForce = 250;
    public float force = 10;

    void Start()
    {
        //spideyanim = GetComponent<Animator>();
        //target = GetComponent<Transform>();
        _animatorPlayer = players.GetComponent<Animator>();
        healthBar = healthBars.GetComponent<Slider>();
        healthBar.maxValue = 10;
        healthBar.value = 5;
    }


    void Update()
    {
        jalan();
        mati();
        healthBar.value = HealthPoint;
    }

    private void mati()
    {
        if (HealthPoint <= 0)
        {
            HealthPoint = 0;
            spideyanim.SetTrigger("dead");
            StartCoroutine(WaitThenDie());
            spidey = 3;
        }
    }

    private void jalan()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        Vector3 targetDir = target.position - transform.position;

        if (spidey == 0)
        {
            spideyanim.SetTrigger("idle");
            if (distance < jarak)
            {
                spidey = 1;
            }
        }
        else if(spidey == 1)
        {
            spideyanim.SetTrigger("walk");
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDir), rotationSpeed * Time.deltaTime);

            if (distance <= 1)
            {
                spidey = 2;
            }
            if (distance > jarak)
            {
                spidey = 0;
            }
        }
        else if (spidey == 2)
        {
            spideyanim.SetTrigger("attack");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDir), rotationSpeed * Time.deltaTime);
            if (distance > 1)
            {
                spidey = 0;
            }
        }
        else if (spidey == 3)
        {
            spideyanim.SetTrigger("dead");
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == player)
        {
            if (_animatorPlayer.GetCurrentAnimatorStateInfo(1).IsName("Attack01_SwordAndShiled"))
            {
                HealthPoint--;
                Knockback();
                Debug.Log("hit");
            }
            
        }
    }

    IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
        GameObject enemy = Instantiate(potion, transform.position, transform.rotation);
    }

    void Knockback()
    {
        Debug.Log("knockback");
        //transform.position += target.transform.forward * Time.deltaTime * KnockbackForce;
        Vector3 pushDirection = transform.position - transform.position;
        pushDirection = -pushDirection.normalized;
        GetComponent<Rigidbody>().AddForce(pushDirection * force * 100);
    }

}
