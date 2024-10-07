using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    //UI ��� ����
    public Text playerNameText;
    public Text metalText;
    public Text crystalText;
    public Text deuteriumText;
    public InputField playerNameInput;

    public Button registerButton;
    public Button loginButton;
    public Button collectButton;
    public Button developButton;
    public Slider progressBar;


    //UI ������Ʈ �޼���
    public void SetPlayerName(string name)
    {
        playerNameText.text = name;
    }

    public void UpdateResources(int metal, int crystal, int deuterium)
    {
        metalText.text = $"Metal: {metal}";
        crystalText.text = $"Crystal : {crystal}";
        deuteriumText.text = $"Deuterium :{deuterium}";
    }

    public void UpdateProgressBar(float value)
    {
        progressBar.value = value;
    }

    //��ư Ŭ�� ������ ���� �޼���
    public void SetRegisterButonListener(UnityEngine.Events.UnityAction action)
    {
        registerButton.onClick.RemoveAllListeners();
        registerButton.onClick.AddListener(action);
    }
    public void SetLoginButonListener(UnityEngine.Events.UnityAction action)
    {
        loginButton.onClick.RemoveAllListeners();
        loginButton.onClick.AddListener(action);
    }
    public void SetCollectButonListener(UnityEngine.Events.UnityAction action)
    {
        collectButton.onClick.RemoveAllListeners();
        collectButton.onClick.AddListener(action);
    }
    public void SetDevelopButonListener(UnityEngine.Events.UnityAction action)
    {
        developButton.onClick.RemoveAllListeners();
        developButton.onClick.AddListener(action);
    }
}
