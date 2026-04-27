using UnityEngine;

public class Boss_test : MonoBehaviour
{
    Animator anim;
    Transform player;
    public Boss_stats boss;
    //public Attack_effect attack_effect;

    public GameObject aoeZonePrefab;
    public float aoeCooldown = 1f; // the rate at which explosion is allowet to spawn. Changes based on boss phase
    private float aoeTimer = 0f;
    

    void Start()
    {
        anim = GetComponent<Animator>();

        // Finds player by tag (we’ll set this later)
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;
    }

    void Update()
    {
        aoeTimer += Time.deltaTime;
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // SIMPLE DECISION (we’ll replace this with search later)
        if (distance < 8f)
        {
            anim.SetTrigger("Attack");
            //attack_effect.Attack();
        }
        if (distance > 20f && distance < 30f)
        {
            anim.SetTrigger("Idle");
        }
        else if (distance >= 30)
        {
            anim.SetTrigger("Tele_AoE");
            
            if(aoeTimer >= aoeCooldown)
            {
                Vector3 pos = player.position;
                Instantiate(aoeZonePrefab, pos, Quaternion.identity);

                aoeTimer = 0f;
            }
        }
    }
}