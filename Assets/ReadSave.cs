using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class ReadSave : BasicRequest
{
    public TMP_InputField checkedId;

    public TextMeshProUGUI outputText;

    private string charName, weapon1, weapon2, charLevel, attackMod, defenceMod;


    protected void Start()
    {
        onIdValueChange = new TMP_InputField.OnChangeEvent();
        onIdValueChange.AddListener(OnIdFieldEnd);
        checkedId.onValueChanged = onIdValueChange;

        request = "http://localhost/runnerGame/readSave.php?";
    }
    public void OnSubmitClick()
    {
        if(idText == "" || idText == null)
        {
            outputText.text = "Not entered id";
            return;
        }
        else
        {
            outputText.text = "";
        }

        StartCoroutine(GetText());
    }

    private IEnumerator GetText()
    {
        webRequest = UnityWebRequest.Get(request + "id=" + idText);
        yield return webRequest.SendWebRequest();

        string res = DownloadHandlerBuffer.GetContent(webRequest);

        if (res.Length > 5)
        {
            Debug.Log(res);
            int i = 0;
            for (; i < res.Length; i++)
            {
                if (res[i] == '.')
                {
                    i++;
                    break;
                }
                charName += res[i];
            }
            for (; i < res.Length; i++)
            {
                if (res[i] == '!')
                {
                    i++;
                    break;
                }
                charLevel += res[i];
            }
            for (; i < res.Length; i++)
            {
                if (res[i] == ':')
                {
                    i++;
                    break;
                }
                attackMod += res[i];
            }
            for (; i < res.Length; i++)
            {
                if (res[i] == '>')
                {
                    i++;
                    break;
                }
                defenceMod += res[i];
            }
            for (; i < res.Length; i++)
            {
                if (res[i] == '<')
                {
                    i++;
                    break;
                }
                weapon1 += res[i];
            }
            for (; i < res.Length; i++)
            {
                weapon2 += res[i];
            }

            outputText.text = $"Имя персонажа - {charName}\nУровень персонажа - {charLevel}\nСила атаки - {attackMod}\nНавык защиты - {defenceMod}\nОружие в левой руке - {weapon1}\nОружие в правой руке - {weapon2}";

        }
        else
        {
            outputText.text = "В базе данных нет такого ID";
        }
        charName = "";
        charLevel = "";
        attackMod = "";
        defenceMod = "";
        weapon1 = "";
        weapon2 = "";
    }
    
}
