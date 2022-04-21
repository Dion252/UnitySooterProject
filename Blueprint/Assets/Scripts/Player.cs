using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    NavMeshAgent navMeshAgent;

    public float mvSpeed;

    ScopesControl scopesControl;

    Pew pew;

    public Transform trunk;

    // Start is called before the first frame update
    void Start()
    {

        navMeshAgent = GetComponent<NavMeshAgent>();

        scopesControl = FindObjectOfType<ScopesControl>();

        navMeshAgent.updateRotation = false;

        pew = FindObjectOfType<Pew>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 vector = Vector3.zero;

        if (Input.GetKey(KeyCode.A)) //x & z changed; y not touching!!!
        {
            vector.x = 1.0f;
        }
        
        if (Input.GetKey(KeyCode.D)) //x & z changed; y not touching!!!
        {
            vector.x = -1.0f;
        }

        if (Input.GetKey(KeyCode.W)) //x & z changed; y not touching!!!
        {
            vector.z = -1.0f;
        }

        if (Input.GetKey(KeyCode.S)) //x & z changed; y not touching!!!
        {
            vector.z = 1.0f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            var from = trunk.position;

            var target = scopesControl.transform.position;

            var to = new Vector3(target.x, from.y, target.z);


            var direction = (to - from).normalized;

            RaycastHit hit;


            if (Physics.Raycast(from, direction, out hit, 900)) // или 100
            {
                if (hit.transform != null)
                {
                    var zombie = hit.transform.GetComponent<Zombie>();

                    if (zombie != null)
                    {
                        zombie.Kill();
                    }
                }

                if (hit.transform != null)
                {
                    var brutalZombie = hit.transform.GetComponent<BrutalZombie>();

                    if (brutalZombie != null)
                    {
                        brutalZombie.brutalZombieHp.Hp = brutalZombie.brutalZombieHp.Hp - 1;

                        if (brutalZombie.brutalZombieHp.Hp == 0)
                        {

                            brutalZombie.Kill();

                        }
                    }

                }

                to = new Vector3(hit.point.x, from.y, hit.point.z);
            }
            else
            {
                to = from + direction * 100;
            }


            pew.Show(from,to);
        }

        navMeshAgent.velocity = vector.normalized * mvSpeed;

        Vector3 front = scopesControl.transform.position - transform.position;

        transform.rotation = Quaternion.LookRotation(new Vector3(front.x, 0, front.z)); // у = 0, исключит наклон вперед при направлении модельки в сторону движения



    }
}
