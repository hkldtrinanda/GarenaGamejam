using Unity.VisualScripting;
using UnityEngine;

public class AbilityPowerP1 : MonoBehaviour
{
    public Health increaseHealth;
    public int maxHealCount = 3; // Jumlah maksimal pemulihan yang diizinkan
    private int currentHealCount = 0;
     // Jumlah pemulihan saat ini

    public GameObject healImage;
    public AudioSource powerUp;  // Combat text for Player 1

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Periksa apakah masih bisa melakukan pemulihan
            if (currentHealCount < maxHealCount)
            {
                increaseHealth.Heal(10);
                
                currentHealCount++;
                powerUp.Play();

                // Tambahkan logika tambahan jika diperlukan setelah melakukan pemulihan
                // Misalnya, menampilkan pesan atau mengubah perilaku setelah mencapai batas
            }
            else
            {
                Debug.Log("Batas pemulihan telah tercapai.");
                healImage.SetActive(false);
                powerUp.Stop();
                // Tambahkan logika tambahan jika diperlukan ketika batas telah tercapai
            }
        }
    }
}
