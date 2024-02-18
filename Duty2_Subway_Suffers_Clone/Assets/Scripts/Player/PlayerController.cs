using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private GameObject playerMesh;
    private PlayerMovement playerMovement;
    [SerializeField] float blinkDuration = 0.5f;
    [SerializeField] int blinkRepeatCount = 5;

    [SerializeField] private GameObject PowerArea;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    public void TakeDamage()
    {
        health--;
        StartCoroutine(BlinkCharacter());
        PowerArea.SetActive(true);
        if (health <= 0)
        {
            Die();
        }
    }

    private IEnumerator BlinkCharacter()
    {

        SkinnedMeshRenderer renderer = playerMesh.GetComponent<SkinnedMeshRenderer>();

        if (renderer == null)
            yield break;

        for (int i = 0; i < blinkRepeatCount; i++)
        {

            renderer.enabled = false;
            yield return new WaitForSeconds(blinkDuration);

            renderer.enabled = true;
            yield return new WaitForSeconds(blinkDuration);
        }
        renderer.enabled = true;
    }

    private void Die()
    {
        playerMovement._animator.SetBool("isRunning", false);
        playerMovement._gameManager.isStarted = false;
    }


}
