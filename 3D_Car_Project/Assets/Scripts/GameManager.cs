using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int checkpointCount, totalCheckpoint, lap;
    public bool gameFinished;
    public UIManager uIManager;
    public float resetTime;

    private void Start()
    {
        totalCheckpoint = FindObjectsOfType<CheckPoint>().Length;
    }
    private void Update()
    {
        if (gameFinished)
        {
            resetTime -= Time.deltaTime;
            if (resetTime <= 0)
            {
                RestartGame();
            }
        }
    }
    public void AddCheckpointCount()
    {
        checkpointCount++;
    }
    public int GetCheckpointCount()
    {
        return checkpointCount;
    }
    public void CompleteLap()
    {
        if (lap >= 3)
        {
            uIManager.Finished();
            gameFinished=true;
        }
        else
        {
            lap++;
            checkpointCount = 0;
            uIManager.SetLapText(lap);
            CheckPoint[] checkPoints = FindObjectsOfType<CheckPoint>();
            for (int i = 0; i < checkPoints.Length; i++)
            {
                checkPoints[i].RefreshCheckpoint();
            }
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
