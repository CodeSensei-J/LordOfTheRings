using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public int goldAmount;
    public int goldAmountPerClick = 5;
    public Text goldAmountText;

    public int goldGenerator;
    public Text goldGeneratorText;
    public int generateGoldPerSecond = 1;

    public int GoldAmount
    {
        get => PlayerPrefs.GetInt("Gold", 0);
        set
        {
            PlayerPrefs.SetInt("Gold", value);
            UpdateGoldAmountLabel();
        }
    }

    void UpdateGoldAmountLabel()
    {
        this.goldAmountText.text = this.GoldAmount.ToString("Gold: 0");
    }

    private void Start()
    {
        UpdateGoldAmountLabel();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ProduceGold();
        }
        this.goldGeneratorText.text = this.goldGenerator.ToString("Gold Generators: 0");
    }

    public void ProduceGold()
    {
        this.GoldAmount += this.goldAmountPerClick;
    }

    public void GoldGenerator()
    {
        if (GoldAmount > 100)
        {
            this.goldGenerator += 1;
            this.GoldAmount -= 100;
        }
        else
        {
            this.goldGenerator += 0;
        }
    }

    

}
