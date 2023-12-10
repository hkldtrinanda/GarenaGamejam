using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Dapatkan komponen SpriteRenderer pada objek ini
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Pastikan SpriteRenderer ada sebelum digunakan
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer tidak ditemukan pada objek ini.");
        }
    }

    // void Update()
    // {
    //     // Panggil metode Flip() jika tombol Flip ditekan
    //     if (Input.GetKeyDown(KeyCode.F))
    //     {
    //         Flip();
    //     }
    // }

    public void Flip()
    {
        // Balikkan arah sprite menggunakan SpriteRenderer.flipX
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
