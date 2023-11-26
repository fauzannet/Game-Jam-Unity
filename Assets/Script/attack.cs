using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    private Animator _animatorPlayer;
    private int CountAttackClick;

    [SerializeField] int time;
    void Start()
    {
        _animatorPlayer = GetComponent<Animator>();
        CountAttackClick = 0;
    }

    private void Update()
    {
        //if (Input.GetButton("Fire1"))
        //{
        //    btnAttack();
        //    Debug.Log("klik bisa");
        //}
        attackbtn();
        shieldbtn();
    }
    public void CheckAttackPhase()
    {
        if (_animatorPlayer.GetCurrentAnimatorStateInfo(1).IsName("Attack01_SwordAndShiled"))
        {
            if (CountAttackClick > 1)
            {
                _animatorPlayer.SetInteger("attackphase", 2);
            }
            else {}
        }
        if (_animatorPlayer.GetCurrentAnimatorStateInfo(1).IsName("Attack02_SwordAndShiled"))
        {
            if (CountAttackClick > 2)
            {
                _animatorPlayer.SetInteger("attackphase", 3);
            }
            else { }
        }
        if (_animatorPlayer.GetCurrentAnimatorStateInfo(1).IsName("Attack03_SwordAndShiled"))
        {
            if (CountAttackClick > 3)
            {
            }
        }
    }

    public void attackbtn()
    {
            
            if (Input.GetButton("Fire1"))
            {
            CountAttackClick++;
            _animatorPlayer.SetInteger("attackphase", 1);
        }
            if (CountAttackClick == 2)
            {
            _animatorPlayer.SetInteger("attackphase", 2);
            }
              if (CountAttackClick == 3)
            {
                _animatorPlayer.SetInteger("attackphase", 3);
            //Debug.Log("Hitung Klick Attack" + CountAttackClick);
            }

            //if (CountAttackClick == 3)
            //{
            //    _animatorPlayer.SetInteger("attackphase", 3);
            //Debug.Log("Hitung Klick Attack" + CountAttackClick);
            //}

            if (CountAttackClick == 4)
            {
            CountAttackClick = 0;
            _animatorPlayer.SetInteger("attackphase", 0);
            //Debug.Log("Hitung Klick Attack" + CountAttackClick);
        }
    }

    public void shieldbtn()
    {

        if (Input.GetButtonDown("shield"))
        {
            StartCoroutine(Action());
            
            Debug.Log("klik tahan");
        }
        if (Input.GetButtonUp("shield"))
        {
            StopCoroutine(Action());
            CountAttackClick = 0;
            Debug.Log("lepas");
            _animatorPlayer.SetInteger("attackphase", 0);
        }

        IEnumerator Action()
        {
            yield return new WaitForSeconds(time);
            _animatorPlayer.SetTrigger("shield");
        }

    }

}
