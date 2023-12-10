using UnityEditor;
using UnityEngine;

public class SkinManager1 : MonoBehaviour
{

    [Header("SR")]
    public SpriteRenderer bgSR;

    [SerializeField]
    private GameObject[] characters;

    [SerializeField]
    private GameObject[] characterIcons;

    private int skinIndex;

    [Header("Panel")]
    public GameObject gameplayPanel, selectPanel, iconPanel;

    public void ChangeSkin(int skinIndex)
    {
        // Nonaktifkan semua karakter
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }

        // Nonaktifkan semua ikon karakter
        for (int i = 0; i < characterIcons.Length; i++)
        {
            characterIcons[i].SetActive(false);
        }

        // Hanya aktifkan karakter dan ikon yang sesuai dengan skinIndex
        characters[skinIndex].SetActive(true);
        characterIcons[skinIndex].SetActive(true);
    }

    public void StartGame()
    {
        // Hanya aktifkan panel gameplay dan nonaktifkan panel select
        gameplayPanel.SetActive(true);
        selectPanel.SetActive(false);
        iconPanel.SetActive(false);
        bgSR.enabled = false;
    }
}