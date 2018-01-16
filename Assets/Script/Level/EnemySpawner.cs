using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [System.Serializable]
    public class Spawn
    {
        public Enemy Enemy;
        public int Amount = 1;
    }

    [SerializeField] Spawn[] Spawns;
    [SerializeField] Transform[] SpawnPoints;

    public List<Enemy> m_Enemies;

    public bool isFinish
    {
        get
        {
            if (m_Enemies != null && m_Enemies.Count <= 0)
                if( GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
                    return true;
            return false;
        }
    }

    void Awake()
    {
        m_Enemies = new List<Enemy>();

        for (int i = 0; i < Spawns.Length; i++)
        {
            for(int j = 0; j < Spawns[i].Amount; j++)
            {
                m_Enemies.Add(Spawns[i].Enemy);
            }
        }
    }


    public void DoSpawn()
    {
        if (!Player.Instance.PlayerHealth.isAlive)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, SpawnPoints.Length);
        int enemySpawnIndex = Random.Range(0, m_Enemies.Count);

        Instantiate(m_Enemies[enemySpawnIndex], SpawnPoints[spawnPointIndex].position, SpawnPoints[spawnPointIndex].rotation);

        m_Enemies.RemoveAt(enemySpawnIndex);
    }
}
