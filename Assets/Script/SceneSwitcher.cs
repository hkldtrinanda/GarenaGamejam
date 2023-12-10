using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject subPanel;
    
    void Update()
    {
        // Memeriksa apakah tombol spasi ditekan
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Memanggil metode untuk memindahkan ke scene lain
            SwitchToNextScene();
        }

        // Memeriksa apakah tombol esc ditekan
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Memanggil metode untuk menampilkan panel
            subPanel.SetActive(true);
        }
    }

    void SwitchToNextScene()
    {
        // Mendapatkan indeks scene saat ini
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Memeriksa apakah ada scene berikutnya
        if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            // Memuat scene berikutnya
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            // Jika tidak ada scene berikutnya, kembali ke scene pertama
            SceneManager.LoadScene(0);
        }
    }

    public void RestartScene()
    {
        // Get the currently active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Reload the current scene
        SceneManager.LoadScene(currentScene.name);
    }

    public void MenuBack()
    {
        // Memuat scene menu
        SceneManager.LoadScene("MainMenu");
    }

    public void CloseSubPanel()
    {
        // Menutup panel
        subPanel.SetActive(false);
    }
}
