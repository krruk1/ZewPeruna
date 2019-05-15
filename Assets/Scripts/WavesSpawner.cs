using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WavesSpawner : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerToNextWave;
    [SerializeField] List<WaveConfig> wavesconfig;
    [SerializeField] bool looping;
    int startingWaveIndex = 0;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);

    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWaveIndex; waveIndex < wavesconfig.Count; waveIndex++)
        {
            Debug.Log(wavesconfig.Count);
            var currentWave = wavesconfig[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }

    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBeteewneSpawns());
        }
        for (float i = waveConfig.GetTimeToNextWave() ; i >= 0 ; i--)
        {
            timerToNextWave.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        timerToNextWave.text = " ";

    }
}
