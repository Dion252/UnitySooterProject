using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    Player player;
    NavMeshAgent navMeshAgent;

    CapsuleCollider capsuleCollider;
    bool death;
    Animator animator;

    MoveAnimationMaker moveAnimationMaker;

    Counter counter;

    public float mvSpeed;

    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<Player>();

        navMeshAgent = GetComponent<NavMeshAgent>();

        capsuleCollider = GetComponent<CapsuleCollider>();

        animator = GetComponentInChildren<Animator>();

        moveAnimationMaker = GetComponent<MoveAnimationMaker>();

        counter = FindObjectOfType<Counter>();

        //navMeshAgent.SetDestination(player.transform.position);

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
