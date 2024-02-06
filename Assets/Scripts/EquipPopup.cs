using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipPopup : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text displayName;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text stats;
    [SerializeField] private TMP_Text checkText;


    public void Set(ItemData item)
    {
        icon.sprite = item.icon;
        displayName.text = item.displayName;
        description.text = item.description;
        stats.text = "";
        stats.text += item.Atk != 0 ? $"공격력 + {item.Atk} " : "";
        stats.text += item.Def != 0 ? $"방어력 + {item.Def} " : "";
        stats.text += item.Hp != 0 ? $"체력 + {item.Hp} " : "";
        stats.text += item.Crt != 0 ? $"치명타 + {item.Crt} " : "";

        checkText.text = "장착 하시겠습니까?";
        //checkText.text = "해제 하시겠습니까?";
    }

    public void Cancel()
    {
        _gameObject.SetActive(false);
    }

    public void Confirm()
    {
        _gameObject.SetActive(false);
    }
}
