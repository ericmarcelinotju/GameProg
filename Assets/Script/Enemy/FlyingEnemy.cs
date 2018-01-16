using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{

    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float rotationalDamp = .5f;

    [SerializeField] float detectionDistance = 10f;
    [SerializeField] float offset = 2.5f;

    [SerializeField] float attackRange = 20f;

    private GameObject player;
    private Transform target;
    private EnemyHealth enemyHealth;

    private bool targetInRange
    {
        get
        {
            float distance = Vector3.Distance(target.position, transform.position);

            return distance <= attackRange;
        }
    }

    public bool isAttacking = false;
    public bool isRetreating = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {

        Debug.Log("Retreat = " + isRetreating);
        Debug.Log("Attack = " + isAttacking);
        if (enemyHealth.HitPointsRemaining <= 0)
        {
            transform.Translate(-Vector3.up * 2.5f * Time.deltaTime);
            return;
        }

        if (isRetreating)
        {
            Retreating();
        }
        if (isAttacking)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 4f * Time.deltaTime);
        }
        else
        {
            Pathing();
        }
    }

    float timer = 0f;

    void Retreating()
    {
        timer += Time.deltaTime;
        if (!targetInRange)
        {
            if(timer >= 4f)
            {
                isRetreating = false;
                isAttacking = false;
            }
        }
        else
        {
            Vector3 pos = (target.position + Vector3.up * 10) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(-pos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
        }
    }

    void Turn()
    {
        Vector3 pos = (target.position + Vector3.up * 10) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    void Pathing()
    {
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;

        Vector3 left = transform.position - transform.right * offset;
        Vector3 right = transform.position + transform.right * offset;

        if (Physics.Raycast(left, transform.forward, out hit, detectionDistance))
            raycastOffset += Vector3.right;
        else if (Physics.Raycast(right, transform.forward, out hit, detectionDistance))
            raycastOffset -= Vector3.right;

        if (raycastOffset != Vector3.zero)
            transform.Rotate(raycastOffset * 5f * Time.deltaTime);
        else
            Turn();

        Move();

        if (targetInRange && !isRetreating)
            isAttacking = true;
    }
}
