using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text lapText;
    public GameObject finishText;

    public void SetLapText(int lap)
    {
        lapText.text = lap.ToString();
    }
    public void Finished()
    {
        finishText.SetActive(true);
    }
}
