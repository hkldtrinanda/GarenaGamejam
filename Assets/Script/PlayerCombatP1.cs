using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerCombatP1 : MonoBehaviour
{
    [Header("Health")]
    public Health damageReceiver, shieldAttack;



    [Header("Combat P1")]
    public TMP_Text combatTextP1;

    public TMP_Text attackPhraseUI;
    public string[] attackPhrases;
    public int damagePerAttack = 10;
    public int shieldPerAttack = 10;

    private string currentPhrase;
    private int currentPhraseIndex = 0;
    private bool isTyping = false;

    void Start()
    {
        DisplayNextPhrase();
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
        combatTextP1.text = "";

        currentPhrase = attackPhrases[currentPhraseIndex];
        UpdateAttackPhraseUI();
    }

    void CheckAttackInput()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b')
            {
                if (combatTextP1.text.Length > 0)
                {
                    combatTextP1.text = combatTextP1.text.Substring(0, combatTextP1.text.Length - 1);
                }


            }
            else
            {
                combatTextP1.text += c;

     
            }
        }
        

    

        if (combatTextP1.text.Equals(currentPhrase, System.StringComparison.OrdinalIgnoreCase))
        {
            isTyping = false;
            ApplyDamage();
            currentPhraseIndex++;
            if (currentPhraseIndex < attackPhrases.Length)
            {
                DisplayNextPhrase();
                isTyping = true;
            }
            else
            {
                Debug.Log("Player menang!");
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
        combatTextP1.text = "";

        UpdateAttackPhraseUI();
    }

    void UpdateAttackPhraseUI()
    {
        attackPhraseUI.text = currentPhrase;
    }

    void ApplyDamage()
    {
        if (damageReceiver != null && damageReceiver.gameObject != null)
        {
            damageReceiver.TakeDamage(damagePerAttack);
            Debug.Log("Player menyerang dan memberikan damage: " + damagePerAttack);
        }

        if (shieldAttack != null && shieldAttack.gameObject != null)
        {
            shieldAttack.HitShield(shieldPerAttack);
            Debug.Log("Player menyerang dan memberikan shield: " + shieldPerAttack);
        }

        
    }
}
