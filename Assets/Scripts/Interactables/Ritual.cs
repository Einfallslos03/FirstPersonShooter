using UnityEngine;
using UnityEngine.AI;

public class Ritual : Interactable
{
    public PlayerHealthBar player;
    public GameObject zombiePrefab;
    public int zombieCount = 5;
    public float spawnRadius = 10f;

    protected override void Interact()
    {
        SpawnZombies();
    }

    void SpawnZombies()
    {
        for (int i = 0; i < zombieCount; i++)
        {
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * spawnRadius;

            if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 5f, NavMesh.AllAreas))
            {
                Instantiate(zombiePrefab, hit.position, Quaternion.identity);
            }
        }
    }

    // Zeigt den Spawn-Bereich in der Scene-Ansicht
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
