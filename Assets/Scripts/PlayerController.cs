using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float spawnInterval = 2f; // Meyve oluþma süresi (saniye cinsinden)

    public GameObject[] Fruits;

    

    public Text Score;
    private int score = 0;

    void Start()
    {
        StartCoroutine(SpawnFruits());
        UpdateScoreUI();
    }

   
    void Update()
    {
        Move();
        
    }


    void Move()
    {

        float clamp = Mathf.Clamp(transform.position.x, -8f, 8f);
        transform.position = new Vector3(clamp, transform.position.y, transform.position.z);
        float yatayHareket = Input.GetAxis("Horizontal") * speed;
 
        transform.Translate(0,0, -yatayHareket * Time.deltaTime);
    }


    

    IEnumerator SpawnFruits()
    {
        while (true) // Sonsuz döngü, oyun boyunca çalýþacak
        {
            int randomIndex = Random.Range(0, Fruits.Length); // Rastgele bir meyve seç
            float randomX = Random.Range(-8f, 9f);
            float randomY = Random.Range(6f, 7f);

            Instantiate(Fruits[randomIndex], new Vector3(randomX, randomY, 0), Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval); // Belirtilen süre kadar bekle
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("fruit"))
        {
            score++;
            UpdateScoreUI();
            Destroy(collision.gameObject);
        }
    }

    void UpdateScoreUI()
    {
        Score.text = "Score: " + score.ToString();
    }



   
}
