using UnityEngine;
using UnityEngine.UI;

public class GoldProductionUnitScript : MonoBehaviour
{
    public GoldProductionUnit goldProductionUnit;
    public Text goldAmountText;
    public Text purchaseButtonLabel;
    float elapsedTime;

    bool IsAffordable => FindObjectOfType<Gold>().GoldAmount >= this.goldProductionUnit.costs;

    public void SetUp(GoldProductionUnit goldProductionUnit)
    {
        this.goldProductionUnit = goldProductionUnit;
        this.gameObject.name = goldProductionUnit.name;
        this.purchaseButtonLabel.text = $"Purchase {goldProductionUnit.name}";
    }

    public int GoldPressAmount
    {
        get => PlayerPrefs.GetInt(this.goldProductionUnit.name, 0);
        set
        {
            PlayerPrefs.SetInt(this.goldProductionUnit.name, value);
            UpdateGoldPressAmountLabel();
        }
    }

    void UpdateGoldPressAmountLabel()
    {
        this.goldAmountText.text = this.GoldPressAmount.ToString($"0 {this.goldProductionUnit.name}");
    }

    private void Start()
    {
        UpdateGoldPressAmountLabel();
    }

    private void Update()
    {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.goldProductionUnit.productionTime)
        {
            ProduceGold();
            this.elapsedTime -= this.goldProductionUnit.productionTime;
        }

        UpdateTextColor();
    }

    void UpdateTextColor()
    {
        this.purchaseButtonLabel.color = this.IsAffordable ? Color.green : Color.red;
    }

    void ProduceGold()
    {
        var gold = FindObjectOfType<Gold>();
        gold.GoldAmount += this.goldProductionUnit.productionAmount * this.GoldPressAmount;
    }

    public void BuyGoldPress()
    {
        var gold = FindObjectOfType<Gold>();
        if (gold.GoldAmount >= this.goldProductionUnit.costs)
        {
            gold.GoldAmount -= this.goldProductionUnit.costs;
            this.GoldPressAmount += 1;
        }
    }

}
