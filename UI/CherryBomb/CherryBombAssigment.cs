using UnityEngine;
using TMPro;
using System.Collections;

public class CharacterTextController : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float changeInterval = 0.5f;
    public float initialSlowDownInterval = 2f; // İlk yavaşlama süresi
    public float finalSlowDownInterval = 5f;   // Son yavaşlama süresi

    private GameObject[] characterObjects;
    private int currentIndex = 0;

    private void Start()
    {
        characterObjects = GameObject.FindGameObjectsWithTag("Character");
        StartCoroutine(ChangeText());
    }

    IEnumerator ChangeText()
    {
        float currentSlowDownInterval = initialSlowDownInterval; // Başlangıçta ilk yavaşlama süresini kullanın

        while (true)
        {
            if (characterObjects.Length > 0)
            {
                textMeshPro.text = characterObjects[currentIndex].name;
                currentIndex = (currentIndex + 1) % characterObjects.Length;
            }

            yield return new WaitForSeconds(changeInterval);

            // Değişimler arasında uyumak için kullanılan yavaşlama süresini güncelleyin
            currentSlowDownInterval -= changeInterval;
            if (currentSlowDownInterval <= 0)
            {
                currentSlowDownInterval = finalSlowDownInterval; // Son yavaşlama süresini kullanın
            }
            yield return new WaitForSeconds(currentSlowDownInterval);
        }
    }
}
