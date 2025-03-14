using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyFruit : MonoBehaviour
{
    public GameObject[] healths;
    private int healthIndex = 0;
    public GameObject GameOverPanel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("fruit"))
        {
            if (healthIndex < healths.Length)
            {
                healths[healthIndex].SetActive(false);
                healthIndex++;
            }

            Destroy(collision.gameObject);

            // E�er canlar bittiyse Game Over panelini a�
            if (healthIndex >= healths.Length)
            {
                GameOverPanel.SetActive(true);
                Time.timeScale = 0.1f; // Tamamen durdurmak yerine �ok yava�lat (Butonlar �al��s�n)
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Oyunu tekrar normal h�z�na getir
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Sahneyi yeniden y�kle
    }
}
