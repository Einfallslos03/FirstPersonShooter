using UnityEngine;
using UnityEngine.AI;
public class ZombieAttackState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    PlayerHealthBar playerHealth;
    float timer;

    public float stopAttackingDistance = 3.5f;
    public float damage = 10f;
    public float attackInterval = 1f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Initialization
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = Object.FindFirstObjectByType<PlayerHealthBar>();
        agent = animator.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LookAtPlayer();
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            playerHealth.TakeDamage(damage);
            timer = attackInterval;
        }
        //Checking if the agent shouldnt attack
        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);

        if (distanceFromPlayer > stopAttackingDistance)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.position - agent.transform.position;
        agent.transform.rotation = Quaternion.LookRotation(direction);

        var yRotation = agent.transform.eulerAngles.y;
        agent.transform.rotation = Quaternion.Euler(0,yRotation,0);
    }
}
