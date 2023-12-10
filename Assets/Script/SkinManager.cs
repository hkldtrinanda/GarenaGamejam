using UnityEditor;
using UnityEngine;

public class SkinManager : MonoBehaviour
{

    [Header("Countdonw Timer")]
    public Animator countdownTimer;


    [Header("SR")]
    public SpriteRenderer bgSR, bgSR2;
    [Header("Character P1 utamakan Genap")]
    [SerializeField]private GameObject[] P1characters;
    [SerializeField] private GameObject[] P1characterIcons;

    [Header("Character P2 utamakan Ganjil")]
    [SerializeField] private GameObject[] P2characterIcons;
    [SerializeField] private GameObject[] P2characters;

    [Header("Maps")]
    [SerializeField] private GameObject[] maps;

    [SerializeField] private GameObject[] mapsIcon;

    private int skinIndexP1;
    private int skinIndexP2;
    private int mapsIndex;

    [Header("Panel")]
    public GameObject gameplayPanel, selectPanel, iconPanel;

    [Header("Audio")]
    private AudioSource audioSource;
    public AudioSource audioManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioManager.Pause();
        audioSource.Play();
        
    }

public void ChangeSkinP1(int skinIndexP1)
{
    // Cek apakah karakter P1 dengan elemen yang sama sudah dipilih oleh P2
    if (P2characters[skinIndexP1].activeSelf)
    {
        Debug.LogWarning("Player 2 has already chosen a character with the same element. Choose a different one.");
        return;
    }

    // Nonaktifkan semua karakter
    for (int i = 0; i < P1characters.Length; i++)
    {
        P1characters[i].SetActive(false);
    }

    // Nonaktifkan semua ikon karakter
    for (int i = 0; i < P1characterIcons.Length; i++)
    {
        P1characterIcons[i].SetActive(false);
    }

    // Hanya aktifkan karakter dan ikon yang sesuai dengan skinIndex
    P1characters[skinIndexP1].SetActive(true);
    P1characterIcons[skinIndexP1].SetActive(true);

    // Update skinIndexP1
    this.skinIndexP1 = skinIndexP1;
}

public void ChangeSkinP2(int skinIndexP2)
{
    // Cek apakah karakter P2 dengan elemen yang sama sudah dipilih oleh P1
    if (P1characters[skinIndexP2].activeSelf)
    {
        Debug.LogWarning("Player 1 has already chosen a character with the same element. Choose a different one.");
        return;
    }

    // Nonaktifkan semua karakter
    for (int i = 0; i < P2characters.Length; i++)
    {
        P2characters[i].SetActive(false);
    }

    // Nonaktifkan semua ikon karakter
    for (int i = 0; i < P2characterIcons.Length; i++)
    {
        P2characterIcons[i].SetActive(false);
    }

    // Hanya aktifkan karakter dan ikon yang sesuai dengan skinIndex
    P2characters[skinIndexP2].SetActive(true);
    P2characterIcons[skinIndexP2].SetActive(true);

    // Update skinIndexP2
    this.skinIndexP2 = skinIndexP2;
}

  public void ChangeMap(int mapsIndex)
    {
        // Nonaktifkan semua karakter
        for (int i = 0; i < maps.Length; i++)
        {
            maps[i].SetActive(false);
        }

        // Nonaktifkan semua ikon karakter
        for (int i = 0; i < mapsIcon.Length; i++)
        {
            mapsIcon[i].SetActive(false);
        }

        // Hanya aktifkan karakter dan ikon yang sesuai dengan skinIndex
        maps[mapsIndex].SetActive(true);
        mapsIcon[mapsIndex].SetActive(true);
    }



    public void StartGame()
    {
        // Hanya aktifkan panel gameplay dan nonaktifkan panel select
        gameplayPanel.SetActive(true);
        selectPanel.SetActive(false);
        iconPanel.SetActive(false);
        bgSR.enabled = false;
        bgSR2.enabled = false;
        audioManager.Play();
        audioSource.Stop();
        countdownTimer.SetTrigger("Start");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Hanya aktifkan panel select dan nonaktifkan panel gameplay
            StartGame();
        }
    }
}