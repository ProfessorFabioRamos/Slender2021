using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerPosition;
    public float scareDistance = 6;
    public UnityEngine.UI.Image scareImg;
    private bool canDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerPosition.position);

        float dist = Vector3.Distance(transform.position,  playerPosition.position);
        
        if(dist < scareDistance && canDamage){
            scareImg.enabled = true;
            playerPosition.GetComponent<Player>().TakeDamage(1);
            canDamage = false;
        }
        else if(dist > scareDistance && !canDamage){
            scareImg.enabled = false;
            canDamage = true;
        }

        //scareImg.enabled = dist < scareDistance?true:false;
    }
}
