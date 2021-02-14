using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


public class BasicRequest : MonoBehaviour
{

    protected string idText;
    protected string nameText;
    protected string levelText;
    protected string atkText = "0";
    protected string defText = "0";
    protected string weap1Text = "Отсутствует";
    protected string weap2Text = "Отсутствует";

    protected TMP_InputField.OnChangeEvent onIdValueChange;
    protected TMP_InputField.OnChangeEvent onNameValueChange;
    protected TMP_InputField.OnChangeEvent onLevelValueChange;
    protected TMP_InputField.OnChangeEvent onAtkValueChange;
    protected TMP_InputField.OnChangeEvent onDefValueChange;
    protected TMP_InputField.OnChangeEvent onWeapon1ValueChange;
    protected TMP_InputField.OnChangeEvent onWeapon2ValueChange;

    protected UnityWebRequest webRequest;

    protected string request;

    public virtual void OnIdFieldEnd(string text)
    {
        idText = text;
    }

    public virtual void OnNameFieldEnd(string text)
    {
        nameText = text;
    }
    public virtual void OnLevelFieldEnd(string text)
    {
        levelText = text;
    }
    public virtual void OnAtkFieldEnd(string atakText)
    {
        atkText = atakText;
    }
    public virtual void OnDefFieldEnd(string defenText)
    {
        defText = defenText;
    }
    public virtual void OnWeapon1FieldEnd(string weapon1)
    {
        weap1Text = weapon1;
    }    
    public virtual void OnWeapon2FieldEnd(string weapon2)
    {
        weap2Text = weapon2;
    }
}
