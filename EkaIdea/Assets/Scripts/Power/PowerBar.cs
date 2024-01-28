using UnityEngine;
using UnityEngine.UI;

public class Powerbar : MonoBehaviour
{
    [SerializeField] private Power playerPower;
    [SerializeField] private Image totalPowerBar;
    [SerializeField] private Image currentPowerBar;

    private void Start()
    {
        totalPowerBar.fillAmount = 1;
    }
    private void Update()
    {
        currentPowerBar.fillAmount = playerPower.currentPower / 3;
    }
}