using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    private Player _player;

    private void Awake()
    {
        _item = GetComponent<Item>().item;
        
    }

    private void Start()
    {
        _player = GameManager.Instance.playerObj.GetComponent<Player>();
        icon.sprite = _item.icon;
        name.text = _item.displayName;
        description.text = _item.description;
        stats.text += _item.Atk != 0 ? $"���ݷ� + {_item.Atk}\n" : "";
        stats.text += _item.Def != 0 ? $"���� + {_item.Def}\n" : "";
        stats.text += _item.Hp != 0 ? $"ü�� + {_item.Hp}\n" : "";
        stats.text += _item.Crt != 0 ? $"ġ��Ÿ + {_item.Crt}\n" : "";
        stats.text += $"���� : {_item.price.ToString("N0")}";
        buyButton.onClick.AddListener(() => OnClickBuy());
    }

    public void OnClickBuy()
    {
        if (Inventory.Instance.GetEmptySlot() == null)
        {
            UIManager.instance.ShopBuyPopup("�κ��丮�� ���� á���ϴ�!");
        }
        else if (_player.gold >= _item.price)
        {
            _player.gold -= _item.price;
            Inventory.Instance.AddItem(_item);
            UIManager.instance.ShopBuyPopup("�����Ͽ����ϴ�!");
        }
        else
        {
            UIManager.instance.ShopBuyPopup("��尡 �����մϴ�!");
        }
    }

}
