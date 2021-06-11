using System.Collections;
using UnityEngine;

public class DeployEnemy : MonoBehaviour
{
    public GameObject enemyPrefabLeft;
    public GameObject enemyPrefabRight;
    public float respawnTime;

    public float speed;

    void Start()
    {
        StartCoroutine(EnemyWave());
    }

    private void SpawnEnemyLeft()
    {
        GameObject a = Instantiate(enemyPrefabLeft) as GameObject;
        a.transform.position = new Vector2(-9, -1.5f);
        if (PlayerBehaviour.score > 5)
        {
            speed = 5;
            respawnTime = 0.5f;
        }
        a.GetComponent<EnemyBehaviour>().moveSpeed = -speed;
    }

    private void SpawnEnemyRight()
    {
        GameObject b = Instantiate(enemyPrefabRight) as GameObject;
        b.transform.position = new Vector2(9, -1.5f);
        b.GetComponent<EnemyBehaviour>().moveSpeed = speed;
    }

    public IEnumerator EnemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime * Random.Range(1.0f, 3.0f));
            SpawnEnemyLeft();

            yield return new WaitForSeconds(respawnTime * Random.Range(1.0f, 3.0f));
            SpawnEnemyRight();
        }
    }
}
