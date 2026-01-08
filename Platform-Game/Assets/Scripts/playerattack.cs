using UnityEngine;

public class playerattack : MonoBehaviour
{


    [SerializeField] private float attackcooldown = 0.5f; 
    private Animator anim;
    private float cooldowntimer = 100f; 
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
        cooldowntimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && cooldowntimer > attackcooldown)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (anim != null)
            anim.SetTrigger("attack");
        cooldowntimer = 0;
    }



    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (cooldowntimer < 0.25f)
            {
                HasarVer(collision.gameObject);
            }
        }
    }

    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            if (cooldowntimer < 0.1f) 
            {
                HasarVer(collision.gameObject);

                
                cooldowntimer = 0.25f;
            }
        }
    }



    void HasarVer(GameObject dusmanObjesi)
    {
        EnemyHealth dusmanSaglik = dusmanObjesi.GetComponent<EnemyHealth>();
        if (dusmanSaglik != null)
        {
            dusmanSaglik.HasarAl(1);
        }
    }
}