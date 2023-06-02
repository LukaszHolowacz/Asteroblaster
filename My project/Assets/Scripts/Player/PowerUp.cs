using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUpPrefab;

    public void SpawnPowerUp(Vector2 position)
    {
        GameObject powerUp = Instantiate(powerUpPrefab, position, Quaternion.identity);
    }
}
