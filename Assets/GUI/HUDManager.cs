using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HUDManager : MonoBehaviour
{
    public WaveSpawner waveSpawner;
    public PlayerStats ps;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI moneyText;

    // Update is called once per frame
    void Update()
    {
        waveText.text = waveSpawner.nextWave.ToString();
        moneyText.text = ps.Money.ToString();
    }
}
