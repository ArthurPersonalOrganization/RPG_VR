using Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IActivable
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float force = 10f;

    public float fireRate = 15f;
    public float nextTimeFire = 0f;

    public void Activate()
    {
        if (Time.time >= nextTimeFire)
        {
            nextTimeFire= Time.time + 1f/fireRate;
            var go = GameObject.Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
            var rb = go.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.forward * force, ForceMode.Impulse );
            Destroy(go, 5f);
        }
    }
}
