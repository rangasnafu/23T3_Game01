using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Slime : MonoBehaviour
{
    public float moveSpeed = 1.0f;

        public GameObject gameOverUI;


    private void Update()
    {
        Vector3 moveDirection = Vector3.up;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (gameOverUI.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Level1");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
        }
    }
}
