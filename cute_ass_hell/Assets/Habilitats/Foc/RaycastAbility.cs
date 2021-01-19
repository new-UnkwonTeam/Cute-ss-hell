using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Abilities/RaycastAbility")]
public class RaycastAbility : Ability
{

    public int gunDamage = 1;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Color fireballColor = Color.white;

    private RaycastShootTriggerable rcShoot;

    public override void Initialize(GameObject obj)
    {
        rcShoot = obj.GetComponent<RaycastShootTriggerable>();
        rcShoot.Initialize();

        rcShoot.gunDamage = gunDamage;
        rcShoot.weaponRange = weaponRange;
        rcShoot.hitForce = hitForce;
        rcShoot.fireball.material = new Material(Shader.Find("Unlit/Color"));
        rcShoot.fireball.material.color = fireballColor;

    }

    public override void TriggerAbility()
    {
        rcShoot.Fire();
    }


}