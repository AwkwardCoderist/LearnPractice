using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class WriteSave : BasicRequest
{
    public TMP_InputField IFName;
    public TMP_InputField IFLevel;
    public TMP_InputField IFAttack;
    public TMP_InputField IFDefence;
    public TMP_InputField IFWeapon1;
    public TMP_InputField IFWeapon2;

    public TextMeshProUGUI outputText;

    protected void Start()
    {
        onNameValueChange = new TMP_InputField.OnChangeEvent();
        onNameValueChange.AddListener(OnNameFieldEnd);
        IFName.onValueChanged = onNameValueChange;
        onLevelValueChange = new TMP_InputField.OnChangeEvent();
        onLevelValueChange.AddListener(OnLevelFieldEnd);
        IFLevel.onValueChanged = onLevelValueChange;
        onAtkValueChange = new TMP_InputField.OnChangeEvent();
        onAtkValueChange.AddListener(OnAtkFieldEnd);
        IFAttack.onValueChanged = onAtkValueChange;
        onDefValueChange = new TMP_InputField.OnChangeEvent();
        onDefValueChange.AddListener(OnDefFieldEnd);
        IFDefence.onValueChanged = onDefValueChange;
        onWeapon1ValueChange = new TMP_InputField.OnChangeEvent();
        onWeapon1ValueChange.AddListener(OnWeapon1FieldEnd);
        IFWeapon1.onValueChanged = onWeapon1ValueChange;
        onWeapon2ValueChange = new TMP_InputField.OnChangeEvent();
        onWeapon2ValueChange.AddListener(OnWeapon2FieldEnd);
        IFWeapon2.onValueChanged = onWeapon2ValueChange;

        request = "http://localhost/runnerGame/writeSave.php?";
    }

    public void OnSubmitClick()
    {
        if (nameText == "" || levelText == "" || nameText == null || levelText == null)
        {
            outputText.text = "Имя и уровень обязательны";
            return;
        }
        else
        {
            outputText.text = "";
        }
        atkText = atkText == "" ? "0" : atkText;
        defText = defText == "" ? "0" : defText;
        weap1Text = weap1Text == "" ? "Отсутствует" : weap1Text;
        weap2Text = weap2Text == "" ? "Отсутствует" : weap2Text;
        webRequest = new UnityWebRequest(request + "name=" + nameText + "&level=" + levelText + "&atk=" + atkText + "&def=" + defText + "&weapon1=" + weap1Text + "&weapon2=" + weap2Text);
        webRequest.SendWebRequest();

        outputText.text = "Ваши данные сохранены!\nИмя вашего персонажа - " + nameText + ", уровень вашего персонажа - " + levelText;
    }
}
