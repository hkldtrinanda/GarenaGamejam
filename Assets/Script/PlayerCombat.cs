using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Health")]
    public Health damageReceiver;
    public Health shieldAttack;

    public TMP_Text player1CombatText;  // Combat text for Player 1
    public TMP_Text player1AttackPhraseUI;

    public TMP_Text player2CombatText;  // Combat text for Player 2
    public TMP_Text player2AttackPhraseUI;

    public string[] attackPhrases;
    public int damagePerAttack = 10;
    public int shieldPerAttack = 10;

    private string currentPhrase;
    private int currentPhraseIndex = 0;
    private bool isTyping = false;

    [Header("Animation")]
    public Animator animator;

    [Header("Audio")]
    private AudioSource audioSource;

    void Start()
    {
        DisplayNextPhrase();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isTyping)
        {
            CheckAttackInput();
        }
        else
        {
            StartTyping();
        }
    }

    void StartTyping()
    {
        isTyping = true;

        if (CompareTag("Player1"))
        {
            player1CombatText.text = "";  // Clear the combat text for Player 1
            currentPhrase = attackPhrases[currentPhraseIndex];
            UpdateAttackPhraseUI(player1AttackPhraseUI);
        }
        else if (CompareTag("Player2"))
        {
            player2CombatText.text = "";  // Clear the combat text for Player 2
            currentPhrase = attackPhrases[currentPhraseIndex];
            UpdateAttackPhraseUI(player2AttackPhraseUI);
        }
    }

void CheckAttackInput()
{
    foreach (char c in Input.inputString)
    {
        if (c == '\b')
        {
            if (CompareTag("Player1"))
            {
                if (player1CombatText.text.Length > 0)
                {
                    player1CombatText.text = player1CombatText.text.Substring(0, player1CombatText.text.Length - 1);
                }
            }
            else if (CompareTag("Player2"))
            {
                if (player2CombatText.text.Length > 0)
                {
                    player2CombatText.text = player2CombatText.text.Substring(0, player2CombatText.text.Length - 1);
                }
            }
        }
        else
        {
            if (CompareTag("Player1") && "WASD".Contains(c.ToString().ToUpper()))
            {
                player1CombatText.text += c;
            }
            else if (CompareTag("Player2") && "JIKL".Contains(c.ToString().ToUpper()))
            {
                player2CombatText.text += c;
            }
        }
    }

    if (CompareTag("Player1") && player1CombatText.text.Equals(currentPhrase, System.StringComparison.OrdinalIgnoreCase))
    {
        isTyping = false;
        ApplyDamage(player1CombatText);
        currentPhraseIndex++;
        if (currentPhraseIndex < attackPhrases.Length)
        {
            DisplayNextPhrase();
            isTyping = true;
        }
        else
        {
            Debug.Log("Player 1 menang!");
        }
    }
    else if (CompareTag("Player2") && player2CombatText.text.Equals(currentPhrase, System.StringComparison.OrdinalIgnoreCase))
    {
        isTyping = false;
        ApplyDamage(player2CombatText);
        currentPhraseIndex++;
        if (currentPhraseIndex < attackPhrases.Length)
        {
            DisplayNextPhrase();
            isTyping = true;
        }
        else
        {
            Debug.Log("Player 2 menang!");
        }
    }
    else if (Input.GetKeyDown(KeyCode.Return))
    {
        Debug.Log("Teks tidak cocok. Coba lagi!");
        isTyping = false;
        DisplayNextPhrase();
    }
}



    void DisplayNextPhrase()
    {
        currentPhrase = attackPhrases[currentPhraseIndex];

        if (CompareTag("Player1"))
        {
            player1CombatText.text = "";  // Clear the combat text for Player 1
            UpdateAttackPhraseUI(player1AttackPhraseUI);
        }
        else if (CompareTag("Player2"))
        {
            player2CombatText.text = "";  // Clear the combat text for Player 2
            UpdateAttackPhraseUI(player2AttackPhraseUI);
        }
    }


    void UpdateAttackPhraseUI(TMP_Text attackPhraseUI)
    {
        attackPhraseUI.text = currentPhrase;
    }

    void ApplyDamage(TMP_Text combatText)
    {
        if (damageReceiver != null && damageReceiver.gameObject != null)
        {
            damageReceiver.TakeDamage(damagePerAttack);
            Debug.Log("Player menyerang dan memberikan damage: " + damagePerAttack);
            animator.SetTrigger("Attack");
            audioSource.Play();
        }

        // if (damageReceivers != null && damageReceivers.gameObject != null)
        // {
        //     damageReceivers.TakeDamage(damagePerAttack);
        //     Debug.Log("Player menyerang dan memberikan damage: " + damagePerAttack);
        //     animator.SetTrigger("Attack");
        //     audioSource.Play();
        // }


        if (shieldAttack != null && shieldAttack.gameObject != null)
        {
            shieldAttack.HitShield(shieldPerAttack);
            Debug.Log("Player menyerang dan memberikan shield: " + shieldPerAttack);
        }
    }
}