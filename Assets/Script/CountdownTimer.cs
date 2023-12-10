using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 60f; // Waktu countdown dalam detik
    private TextMeshProUGUI countdownText;
    public GameObject KOText;
    public AudioSource KOAudio;

    private void Start()
    {
        countdownText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (countdownTime > 0)
        {
            UpdateCountdownText();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        KOText.SetActive(true);
        Time.timeScale = 0;
        KOAudio.Play();
        // Tambahkan logika atau tindakan yang ingin Anda lakukan setelah countdown selesai di sini.
    }

    private void UpdateCountdownText()
    {
        int seconds = Mathf.FloorToInt(countdownTime % 60f);
        countdownText.text = string.Format("{0:00}", seconds);
    }

}
