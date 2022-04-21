using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BrutalZombieHp 
{
    public int Hp { get; set; }

}

public class BrutalZombie : MonoBehaviour
{
    Player player;
    NavMeshAgent navMeshAgent;

    CapsuleCollider capsuleCollider;
    Animator animator;

    MoveAnimationMaker moveAnimationMaker;
    Counter counter;


    public BrutalZombieHp brutalZombieHp = (new BrutalZombieHp()
    {
        Hp = 3
    });

    bool death;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

        navMeshAgent = GetComponent<NavMeshAgent>();

        capsuleCollider = GetComponent<CapsuleCollider>();

        animator = GetComponentInChildren<Animator>();


        moveAnimationMaker = GetComponent<MoveAnimationMaker>();

        counter = FindObjectOfType<Counter>();

        //Hp = 3;

    }

    // Update is called once per frame
    void Update()
    {
        if (death)
        {
            return;
        }

        navMeshAgent.SetDestination(player.transform.position);
    }


    public void Kill()
    {

        if (!death)
        {
            death = true;

            counter.AddForKill();

            Destroy(capsuleCollider);

            Destroy(navMeshAgent);

            Destroy(moveAnimationMaker);

            animator.SetTrigger("death");
        }

    }

}
