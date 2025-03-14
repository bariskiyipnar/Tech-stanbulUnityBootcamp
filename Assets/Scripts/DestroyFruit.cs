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

            // Eðer canlar bittiyse Game Over panelini aç
            if (healthIndex >= healths.Length)
            {
                GameOverPanel.SetActive(true);
                Time.timeScale = 0.1f; // Tamamen durdurmak yerine çok yavaþlat (Butonlar çalýþsýn)
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Oyunu tekrar normal hýzýna getir
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Sahneyi yeniden yükle
    }
}
