using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public void startGame(int characterIndex)
    {
        PlayerPrefs.SetInt("selectedCharacter", characterIndex);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
