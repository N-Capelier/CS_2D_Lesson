using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;

    public string playerName;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OnTextSelected()
    {
        if(inputField.text == inputField.placeholder.gameObject.GetComponent<TextMeshProUGUI>().text)
        {
            inputField.text = "";
        }
    }

    public void OnTextChanged()
    {
        playerName = inputField.text;
    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene("Level1");
    }
}
