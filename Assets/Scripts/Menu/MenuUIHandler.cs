using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;
    [SerializeField]
    private TextMeshProUGUI scooresField;

    private void Start()
    {
        if (DataManager.Instance.playerName != "")
        {
            inputField.text = DataManager.Instance.playerName;
        }
        scooresField.text = $"Best Score: {DataManager.Instance.scores}";
    }


    public void SetName()
    {
        DataManager.Instance.playerName = inputField.text;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataManager.Instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }

}
