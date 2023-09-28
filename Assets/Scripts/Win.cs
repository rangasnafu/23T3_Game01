using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject winUI;
    public GameObject timerUI;
    public GameObject slime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (winUI.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Level1");
        }

        if (winUI.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            winUI.SetActive(false);
            timerUI.SetActive(false);
            slime.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 1f;
            winUI.SetActive(true);
        }
    }
}
