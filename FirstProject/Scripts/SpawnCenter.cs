using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnCenter : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public EnemyHealth[] enemies;
        public int count;
        public float timeBetweenSpawns;
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves;

    private Wave currentWave;
    private int index;
    private Transform player;

    private bool finished;

    public void StartButton(Transform playerT)
    {
        player = playerT;
        index = 0;
        StartCoroutine(StartNextWave(index));

    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];
        for (int i = 0; i < currentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
                //GAMEOVER
            }

            EnemyHealth randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform spawnSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, spawnSpot.position, spawnSpot.rotation);

            if (i == currentWave.count - 1)
            {
                finished = true;
            }
            else
            {
                finished = false;
            }

            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);


        }
    }

    private void Update()
    {
        if (finished == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finished = false;
            if (index + 1 < waves.Length)
            {
                index++;
                StartCoroutine(StartNextWave(index));
            }
            else
            {
                Debug.Log("GAME FINISHED");
            }
        }
    }

}
