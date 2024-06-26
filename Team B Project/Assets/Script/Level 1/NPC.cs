using UnityEngine;
using DialogueEditor;

public class NPC : MonoBehaviour
{
    private bool isPlayerInRange; // To check if the player is in interaction range
    public NPCConversation conversation; // Reference to the dialogue manager

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && AllEnemiesDefeated())
        {
            TriggerDialogue();
        }
    }

    private void TriggerDialogue()
    {
        // Call the dialogue manager to start the dialogue
        ConversationManager.Instance.StartConversation(conversation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private bool AllEnemiesDefeated()
    {
        // Check if all enemies are defeated
        return EnemyManager.Instance != null && EnemyManager.Instance.GetRemainingEnemies() == 0;
    }
}
