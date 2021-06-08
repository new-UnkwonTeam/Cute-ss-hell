using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceUnit : MonoBehaviour
{
    public GameObject projectils;
    public Transform spawnProyectilPoint;
    public int damage;
    private Transform playerPos;
    public float attackDistance;
    public float attackSpeed;
    public float attackTimer;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Update()
    {
        Vector3 direction = transform.position - playerPos.position;

        attackSpeed += Time.deltaTime;
        if (playerPos == null) return;
        
        damage:

            Vector3 pos = playerPos.transform.position;

            float distance = (transform.position - pos).magnitude;
            Quaternion targetRotation = Quaternion.LookRotation(pos - transform.position);
            if ((distance > attackDistance) || (attackSpeed < attackTimer)) return;
            Debug.Log("ESTA PEGANDO ");
            GetComponent<Enemic>().currrentStates = Enemic.EnemyStates.attack;

            attackSpeed = 0;

            Quaternion projectileRotation =
                Quaternion.LookRotation(spawnProyectilPoint.position - playerPos.transform.position);
            projectileRotation.x = 0;
            projectileRotation.y = 0;
            disparar(projectileRotation);
    }

    public void disparar(Quaternion projectileRotation)
    {
        GameObject projectile = Instantiate(projectils, spawnProyectilPoint.position, projectileRotation);
        ProjjectilEnemic projectilEnemic =
                projectile.GetComponent<ProjjectilEnemic>();
        projectilEnemic.damage = damage;
        projectilEnemic.launchForce = 10;
    }
}
