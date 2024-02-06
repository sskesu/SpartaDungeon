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
        stats.text += item.Atk != 0 ? $"���ݷ� + {item.Atk} " : "";
        stats.text += item.Def != 0 ? $"���� + {item.Def} " : "";
        stats.text += item.Hp != 0 ? $"ü�� + {item.Hp} " : "";
        stats.text += item.Crt != 0 ? $"ġ��Ÿ + {item.Crt} " : "";

        checkText.text = "���� �Ͻðڽ��ϱ�?";
        //checkText.text = "���� �Ͻðڽ��ϱ�?";
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
