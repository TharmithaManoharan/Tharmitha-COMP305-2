using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public float weaponDamage = 5.0f;
    public Transform attackCheck;
    public float attackCheckRadius = 0.2f;
    public LayerMask defineAttack;

    private Animator animator;
    private bool isAttacking = false;
    private Collider2D col2D;

	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetAxis("Fire1") > 0.0f && !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");

            col2D = Physics2D.OverlapCircle(attackCheck.position, attackCheckRadius, defineAttack);

            if (col2D != null && col2D.tag == "Enemy")
            {
                Debug.Log("Enemy Hit");
                col2D.GetComponent<EnemyHealth>().Damage(weaponDamage);
            }

        }

	}

    public void ResetAttack()
    {
        isAttacking = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
}
