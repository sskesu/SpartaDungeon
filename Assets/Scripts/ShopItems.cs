using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItems : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text stats;
    [SerializeField] private Button buyButton;

    private ItemData _item;
    private void Awake()
    {
        _item = GetComponent<Item>().item;
    }

    private void Start()
    {
        icon.sprite = _item.icon;
        name.text = _item.displayName;
        description.text = _item.description;
        stats.text += _item.Atk != 0 ? $"���ݷ� + {_item.Atk}\n" : "";
        stats.text += _item.Def != 0 ? $"���� + {_item.Def}\n" : "";
        stats.text += _item.Hp != 0 ? $"ü�� + {_item.Hp}\n" : "";
        stats.text += _item.Crt != 0 ? $"ġ��Ÿ + {_item.Crt}\n" : "";
        stats.text += $"���� : {_item.price.ToString("N0")}";
    }

}
