    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
     
    public class characterSelection : MonoBehaviour {
     
        [Header("Character List Parent Reference")]
        public GameObject characterListParent;
     
        private GameObject[] characterList;
        private int index;
     
        [Header("Turn Table Properties")]
        public bool turnTable = true;
     
        public bool rotateX = false;
        public bool rotateY = false;
        public bool rotateZ = false;
     
        public float rotationSpeed = 25.0f;
     
        private void Start() {
            index = PlayerPrefs.GetInt("characterSelected");
     
            characterList = new GameObject[transform.childCount];
     
            // Fill the array with our models ( all children of parent )
            for (int i = 0; i < transform.childCount; i++)
                characterList[i] = transform.GetChild(i).gameObject;
     
            // Toggle off their renderer
            foreach (GameObject go in characterList)
                go.SetActive(false);
     
            // Toggle on the selected character
            if (characterList[index])
                characterList[index].SetActive(true);
        }
     
        private void Update () {
            if (turnTable == true) {
                if(rotateX) {
                    characterListParent.transform.Rotate (rotationSpeed * Time.deltaTime,0,0);
                }
                if(rotateY) {
                    characterListParent.transform.Rotate (0,rotationSpeed * Time.deltaTime,0);
                }
                if(rotateZ) {
                    characterListParent.transform.Rotate (0,0, rotationSpeed * Time.deltaTime);
                }
            }
        }
     
        public void toggleLeft() {
            // Toggle off the current model
            characterList[index].SetActive(false);
     
            index--; // Alternatives : index -=1; index = index - 1;
            if (index < 0)
                // Make sure we are not out of array range
                index = characterList.Length - 1;
     
            // Toggle on the new model
            characterList[index].SetActive(true);
        }
     
        public void toggleRight() {
            // Toggle off the current model
            characterList[index].SetActive(false);
     
            index++;
            if (index == characterList.Length)
                index = 0;
     
            // Toggle on the new model
            characterList[index].SetActive(true);
        }
     
        public void selectButton() {
            // Save our 'character' selection
            PlayerPrefs.SetInt("characterSelected", index);
            SceneManager.LoadScene("scene_GOTO");
        }
    }
