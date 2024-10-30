using System.Runtime.CompilerServices;
using UnityEngine;

public class Gun2 : MonoBehaviour
{
    private void Update()
    {
        Aim();
    }

    [SerializeField] private LayerMask groundMask;

    private Camera mainCamera;

    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    
    private void Start()
    {
        mainCamera = Camera.main;
        
    }
    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
         
    }
    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            //calculate direction
            var direction = position - transform.position;
            // ignore height
            direction.y = 0;
            //make it look that direction
            transform.forward = direction;
            
     
        }
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }

        void shoot()
        {
            {
                //calculate direction
                var direction = position - transform.position;
                // ignore height
                direction.y = 0;
                //make it look that direction
                transform.forward = direction;

            }
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * 120, ForceMode.Impulse);
        }
    }




}
