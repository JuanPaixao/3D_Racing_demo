using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed, turnSpeed;
    public GameManager gameManager;

    private void Update()
    {
        float movHor = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        transform.Rotate(0f, movHor * turnSpeed * Time.deltaTime, 0f);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            CheckPoint checkpoint = other.gameObject.GetComponent<CheckPoint>();
            if (checkpoint.validCheckpoint && checkpoint.id == gameManager.checkpointCount)
            {
                gameManager.AddCheckpointCount();
                checkpoint.validCheckpoint = false;
            }
        }
        if (other.gameObject.CompareTag("Overhead"))
        {
            int checkPointTemp = gameManager.GetCheckpointCount();
            if (checkPointTemp >= gameManager.totalCheckpoint)
            {
                gameManager.CompleteLap();
                Debug.Log("Lap");
            }
        }
    }
}
