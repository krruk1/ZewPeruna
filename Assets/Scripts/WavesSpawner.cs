using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WavesSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float TimeBeetweneWaves = 5f;
    public float countdown = 1f;
    public int waveIndex = 0;

    public Text waveCountDownText;
    // Update is called once per frame
    void Update()
    {

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = TimeBeetweneWaves;
        
        }

        countdown -= Time.deltaTime;
        waveCountDownText.text = Mathf.Round(countdown).ToString();

    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.4f);
        }
        

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab , spawnPoint.position , spawnPoint.rotation);

    }
}
