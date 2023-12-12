using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BombInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject cherryBombPrefab;
    [SerializeField] private float spawnTime, cherryBombScale;
    public TMP_Text resetCounterText;
    private int childCount;

    private bool onProcess = false;

    private Transform character; // Karakterin Transform bileşeni

    private void Start()
    {
        character = GameObject.FindWithTag("Character").transform; // Karakteri etiket kullanarak bulun, uygun etiketi kullanmalısınız
        StartCoroutine(SpawnBomb());
    }

    void Update()
    {
        if (this.gameObject.transform.childCount < childCount && !onProcess)
        {
            StartCoroutine(SpawnBomb());
        }
    }

    IEnumerator SpawnBomb()
    {
        StartCoroutine(ResetCounter());
        onProcess = true;
        yield return new WaitForSeconds(spawnTime);

        GameObject cherryBomb = Instantiate(cherryBombPrefab, transform);
        childCount = this.gameObject.transform.childCount;
        cherryBomb.transform.localPosition = new Vector3(0, 50, 0);
        cherryBomb.transform.localScale *= cherryBombScale;

        onProcess = false;
    }

    IEnumerator ResetCounter()
    {
        float countdown = spawnTime;
        while (countdown > 0)
        {
            resetCounterText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;
        }
        resetCounterText.text = "BOMB IS READY!";
    }

    void LateUpdate()
    {
        if (resetCounterText != null && character != null)
        {
            // Metni karakterin pozisyonuna ve bakış yönüne göre döndürün ve Y ekseni etrafında 180 derece döndürün.
            Vector3 characterPosition = character.position;
            Vector3 textPosition = resetCounterText.transform.position;

            // Metni karakterin bakış yönüne göre döndürün.
            Vector3 lookDirection = characterPosition - textPosition;
            lookDirection.y = 0;

            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            resetCounterText.transform.rotation = rotation * Quaternion.Euler(0, 180, 0); // Y ekseni etrafında 180 derece döndürün.
        }
    }
}
