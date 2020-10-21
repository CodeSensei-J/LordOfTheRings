using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public int goldAmountPerClick = 5;
    public Text goldAmountText;

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
    }
    
    public void ProduceGold()
    {
        this.GoldAmount += this.goldAmountPerClick;
    }
}
