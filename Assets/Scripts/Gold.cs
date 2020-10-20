using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public int goldAmount;
    public Text goldAmountText;


    private void Start()
    {
        this.goldAmount = PlayerPrefs.GetInt("Gold", 0);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Gold", this.goldAmount);
    }

    void Update()
    {
        this.goldAmountText.text = this.goldAmount.ToString("Gold: 0");
        if (Input.GetMouseButtonDown(0))
        {
            ProduceGold();
        }
    }

    public void ProduceGold()
    {
        this.goldAmount += 5;
    }
}
