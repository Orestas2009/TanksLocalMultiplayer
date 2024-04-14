
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLootbox : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    private GameObject randomBullet;
    private void Start()
    {
        randomBullet = bulletPrefab[Random.Range(0, bulletPrefab.Length)];
    }
    private void OnCollisionEnter(Collision other)
    {
        //TODO: play sound
        if (other.transform.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>();
            player.bulletPrefab = randomBullet; 
            Destroy(gameObject);
        }
    }
}
