using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float Range = 100.0f;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private bool isSemiAutomatic = false;
    [SerializeField] private float shootDelay = 0.3f;
    private Camera mainCamera;
    private float nextShootTime;
    private bool isFiring;

    private void Start()
    {
        mainCamera = GetComponentInParent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!isSemiAutomatic && isFiring)
        {
            FireWeapon();
        }
    }

    public void OnFireInput(bool pressed)
    {
        if (isSemiAutomatic)
        {
            if (pressed)
                FireWeapon();
        }
        else
        {
            isFiring = pressed;
        }
    }

    public void FireWeapon()
    {
        if (Time.time < nextShootTime)
            return;

        nextShootTime = Time.time + shootDelay;
        RaycastHit hit;
        if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, Range, layerMask ))
        {
            if(hit.collider.TryGetComponent(out EnemyHealth enemyHealth))
            {
                Debug.Log($"Hit target {enemyHealth.name}");
                enemyHealth.TakeDamage(20);
            }
        }
    }
}
