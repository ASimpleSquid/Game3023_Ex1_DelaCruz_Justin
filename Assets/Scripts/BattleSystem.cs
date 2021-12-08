using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject Player;
    public GameObject Enemy;

    public Animator SceneTransition;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHud playerHUD;
    public BattleHud enemyHUD;

    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }
    IEnumerator LoadLevel()
    {
        SceneTransition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("SampleScene");

    }
    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(Player);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(Enemy);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = enemyUnit.unitName + " Challanges You!";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "Successful Hit!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerBlock()
    {
        dialogueText.text = "You Blocked! No Damage Taken!";

        yield return new WaitForSeconds(2f);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerHeal()
    {
        if (playerUnit.currentMana >= 0)
        {
            dialogueText.text = "You Healed!";
            playerUnit.Heal(playerUnit.heal);
            playerHUD.SetMana(playerUnit.currentMana);
        }
        else
        {
            dialogueText.text = "Not Enough Mana!";
            playerHUD.SetMana(playerUnit.currentMana);
        }

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You Won!";
            yield return new WaitForSeconds(2f);
            StartCoroutine("LoadLevel");
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You Lost! Game Over!";
            SceneManager.LoadScene("MenuScene");
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = "The enemy just stands there, menacingly...";
        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "What will you do?";
    }

    public void onAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void onBlockButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerBlock());
    }

    public void onHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

    public void onFleeButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        dialogueText.text = "You Fled The Battle!";
        StartCoroutine("LoadLevel");
    }
}
