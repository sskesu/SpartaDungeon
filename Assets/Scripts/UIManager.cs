
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private TMP_Text playerName;
    [SerializeField] private TMP_Text playerLv;
    [SerializeField] private TMP_Text playerExp;
    [SerializeField] private Slider expSlider;

    [SerializeField] private GameObject optionButtons;
    [SerializeField] private GameObject statusUI;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject equipPopup;
    [SerializeField] private GameObject shopPopup;
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject exitUI;

    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button raidButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private TMP_Text playerAtk;
    [SerializeField] private TMP_Text playerDef;
    [SerializeField] private TMP_Text playerHp;
    [SerializeField] private TMP_Text playerCrt;

    [SerializeField] private TMP_Text playerGold;

    [SerializeField] private TMP_Text inventoryItemAmount;
    [SerializeField] private TMP_Text shopPopupText;

    private Player _player;
    private EquipPopup _equipPopup;

    private int invenCount;

    private void Awake()
    {
        instance = this;
        _player = GameManager.Instance.playerObj.GetComponent<Player>();
        _equipPopup = equipPopup.GetComponent<EquipPopup>();

        statusButton.onClick.AddListener(() => OpenStatus());
        inventoryButton.onClick.AddListener(() => OpenInventory());
        shopButton.onClick.AddListener(() => OpenShop());
        raidButton.onClick.AddListener(() => PlayRaid());
        exitButton.onClick.AddListener(() => ClosePopup());
    }


    private void Start()
    {
        UpdateUI();
    }

    private void OpenStatus()
    {
        optionButtons.SetActive(false);
        statusUI.SetActive(true);
        exitUI.SetActive(true);
    }

    private void OpenInventory()
    {
        optionButtons.SetActive(false);
        inventoryUI.SetActive(true);
        exitUI.SetActive(true);
    }

    private void OpenShop()
    {
        shopUI.SetActive(true);
    }

    private void PlayRaid()
    {
        _player.gold += Random.Range(700, 1301);
        _player.GetPlayerExp(Random.Range(30, 100));
        UpdateUI();
    }

    public void UpdateUI()
    {
        playerName.text = _player.name;
        playerLv.text = $"Lv. {_player.level.ToString()}";
        playerExp.text = $"{_player.currentExp.ToString()} / {_player.requiredExp.ToString()}";
        expSlider.value = (float)_player.currentExp / _player.requiredExp;
        // 공격력
        playerAtk.text = _player.currentAtk.ToString();
        if (_player.currentAtk > _player.baseAtk)
        {
            playerAtk.text += $" (+{_player.currentAtk - _player.baseAtk})";
        }
        else if (_player.currentAtk < _player.baseAtk)
        {
            playerAtk.text += $" ({_player.currentAtk - _player.baseAtk})";
        }
        // 방어력
        playerDef.text = _player.currentDef.ToString();
        if (_player.currentDef > _player.baseDef)
        {
            playerDef.text += $" (+{_player.currentDef - _player.baseDef})";
        }
        else if (_player.currentDef < _player.baseDef)
        {
            playerDef.text += $" ({_player.currentDef - _player.baseDef})";
        }
        // 체력
        playerHp.text = _player.currentHp.ToString();
        if (_player.currentHp > _player.baseHp)
        {
            playerHp.text += $" (+{_player.currentHp - _player.baseHp})";
        }
        else if (_player.currentHp < _player.baseHp)
        {
            playerHp.text += $" ({_player.currentHp - _player.baseHp})";
        }
        // 치명타
        playerCrt.text = _player.currentCrt.ToString();
        if (_player.currentCrt > _player.baseCrt)
        {
            playerCrt.text += $" (+{_player.currentCrt - _player.baseCrt})";
        }
        else if (_player.currentCrt < _player.baseCrt)
        {
            playerCrt.text += $" ({_player.currentCrt - _player.baseCrt})";
        }

        playerGold.text = _player.gold.ToString("N0");

        invenCount = 0;
        foreach (var item in Inventory.Instance.slots)
        {
            if (item.item != null)
                invenCount++;
        }
        inventoryItemAmount.text = $"{invenCount.ToString()} / {Inventory.Instance.slots.Length}";
    }

    public void ClosePopup()
    {
        optionButtons.SetActive(true);
        statusUI.SetActive(false);
        inventoryUI.SetActive(false);
        shopUI.SetActive(false);
        exitUI.SetActive(false);
    }

    public void OpenEquipPopup(ItemData item)
    {
        equipPopup.SetActive(true);
        _equipPopup.Set(item);
    }

    public void ShopBuyPopup(string str)
    {
        shopPopup.SetActive(true);
        shopPopupText.text = str;
    }

    public void ShopBuyPopupExit()
    {
        shopPopup.SetActive(false);
    }
}
