using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    float mass = 1f;
    int powerUpLayer = LayerMask.NameToLayer("NewPowerUp");

    int randomizedPositions = Random.Range(0, possiblePositions.Length - 1);

    float randomizedXPosition = Random.Range(possiblePositions[randomizedPositions].minXSpawnPoint, possiblePositions[randomizedPositions].maxXSpawnPoint);
    float randomizedYPosition = Random.Range(possiblePositions[randomizedPositions].minYSpawnPoint, possiblePositions[randomizedPositions].maxYSpawnPoint);

    Vector2 spawnPoint = new Vector2(randomizedXPosition, randomizedYPosition);
}
