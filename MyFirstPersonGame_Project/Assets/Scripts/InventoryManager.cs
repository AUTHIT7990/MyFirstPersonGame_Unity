using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private int batteryCount = 0;
    // public int batteriesToWin: กำหนดจำนวนแบตเตอรี่ที่ต้องเก็บเพื่อชนะใน Inspector
    public int batteriesToWin = 5; // ตัวอย่าง: ต้องเก็บ 5 ก้อนเพื่อชนะ

    [SerializeField] private TextMeshProUGUI batteryCountText;
    [SerializeField] private TextMeshProUGUI latestCollectedText;

    // Canvas/Panel ที่จะแสดงเมื่อชนะ หรือแพ้
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateBatteryCountUI();
        latestCollectedText.text = "";

        // ซ่อน Panel ชนะ/แพ้ เมื่อเริ่มเกม
        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);
    }

    public void AddBattery()
    {
        batteryCount++;
        UpdateBatteryCountUI();
        ShowCollectedItemMessage("Battery");
        CheckWinCondition(); // ตรวจสอบเงื่อนไขชนะทุกครั้งที่เก็บแบตเตอรี่
    }

    private void UpdateBatteryCountUI()
    {
        if (batteryCountText != null)
        {
            batteryCountText.text = "Batteries: " + batteryCount + " / " + batteriesToWin; // แสดงจำนวนแบตเตอรี่ที่ต้องเก็บ
        }
    }

    private void ShowCollectedItemMessage(string itemName)
    {
        if (latestCollectedText != null)
        {
            latestCollectedText.text = "Collected: " + itemName;
            Invoke("ClearCollectedItemMessage", 2f);
        }
    }

    private void ClearCollectedItemMessage()
    {
        if (latestCollectedText != null)
        {
            latestCollectedText.text = "";
        }
    }

    // ฟังก์ชันตรวจสอบเงื่อนไขการชนะ
    private void CheckWinCondition()
    {
        if (batteryCount >= batteriesToWin)
        {
            WinGame(); // ถ้าเก็บครบ ให้ชนะเกม
        }
    }

    // ฟังก์ชันเมื่อชนะเกม
    public void WinGame()
    {
        Debug.Log("You Win!");
        if (winPanel != null)
        {
            winPanel.SetActive(true); // แสดง Panel ชนะ
        }
        Time.timeScale = 0f; // หยุดเวลาในเกม (ทำให้ทุกอย่างหยุดนิ่ง)
        // แสดงเมาส์และปลดล็อก (ถ้าต้องการให้ผู้เล่นกดปุ่มใน UI)
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // ฟังก์ชันเมื่อแพ้เกม (จะถูกเรียกจาก TimerManager)
    public void LoseGame()
    {
        Debug.Log("You Lose!");
        if (losePanel != null)
        {
            losePanel.SetActive(true); // แสดง Panel แพ้
        }
        Time.timeScale = 0f; // หยุดเวลาในเกม
        // แสดงเมาส์และปลดล็อก
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}