using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool validCheckpoint;
    public int id;
    private void Start()
    {
        validCheckpoint = true;
    }

    public void RefreshCheckpoint()
    {
        validCheckpoint = true;
    }
}
