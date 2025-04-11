using System.Collections;
using UnityEditor;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public Transform looking;
    [SerializeField] bool canShoot = true;
    [SerializeField] GameObject[] Portals = new GameObject[2];
    [SerializeField] int portalNumber = 0;

    // Update is called once per frame
    void Update()
    {
        LayerMask interactions = LayerMask.GetMask("Movable");

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit ray, 30f, interactions) && Input.GetMouseButton(1))
        {
            Debug.Log("a");
            ray.transform.position = looking.transform.position;
        }
        else if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 50f) && Input.GetMouseButton(0) && canShoot)
        {
            CreatePortal();
            Instantiate(Portals[portalNumber], hit.point, Quaternion.Euler(0,0,0));
            portalNumber++;
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward));
    }

    void CreatePortal()
    {
        canShoot = false;

        if (portalNumber > 1)
        {
            portalNumber = 0;
            GameObject[] destroyPortals;
            destroyPortals = GameObject.FindGameObjectsWithTag("Portal");
            foreach (GameObject oneObject in destroyPortals)
                {
                    Destroy(oneObject);
                }
 

        }

        StartCoroutine(nameof(PortalCooldown));
    }

    IEnumerator PortalCooldown()
    {
        yield return new WaitForSeconds(2);
        canShoot = true;
    }
}

