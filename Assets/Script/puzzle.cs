using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class puzzle : MonoBehaviour
{
    public GameObject batua, batub, batuc, batuaaktif, batubaktif, batucaktif, animator, particleobj1, particleobj2, particleobj3, portals, portalend;
    private Animator _animatorPlayer, portal;
    private ParticleSystem particle1, particle2, particle3;
    public string scene2;
    private int id;
    void Start()
    {
        _animatorPlayer = animator.GetComponent<Animator>();
        portal = portals.GetComponent<Animator>();
        particle1 = particleobj1.GetComponent<ParticleSystem>();
        particle2 = particleobj2.GetComponent<ParticleSystem>();
        particle3 = particleobj3.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Alur Puzzle BAC

    }

    void OnCollisionEnter(Collision batu)
    {
        if (batu.gameObject == batua)
        {
            if (_animatorPlayer.GetCurrentAnimatorStateInfo(1).IsName("Attack01_SwordAndShiled"))
            {
                id = 1;
                particle1.Play(true);
                batua.SetActive(false);
                batuaaktif.SetActive(true);
                //Debug.Log("Batu A");
            }
        }
        if (batu.gameObject == batub)
        {
            if (_animatorPlayer.GetCurrentAnimatorStateInfo(1).IsName("Attack01_SwordAndShiled"))
            {
                id = 2;
                particle2.Play(true);
                batub.SetActive(false);
                batubaktif.SetActive(true);
                //Debug.Log("Batu B");
            }
        }
        if (batu.gameObject == batuc)
        {
            if (_animatorPlayer.GetCurrentAnimatorStateInfo(1).IsName("Attack01_SwordAndShiled"))
            {
                if (id == 1)
                {
                    particle3.Play(true);
                    batuc.SetActive(false);
                    batucaktif.SetActive(true);
                    Debug.Log("Batu Aktif");
                    portal.SetTrigger("turun");
                }
                if (id == 2)
                {
                    batua.SetActive(true);
                    batub.SetActive(true);
                    batuc.SetActive(true);
                    batuaaktif.SetActive(false);
                    batubaktif.SetActive(false);
                    batucaktif.SetActive(false);
                    Debug.Log("Batu Di Reset");
                }

            }
        }
        if (batu.gameObject == portalend)
        {
            SceneManager.LoadScene(scene2);
            Debug.Log("kolisin");
        }
    }

}
