using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    // public static TimerManager Instance: Singleton Pattern สำหรับ TimerManager
    public static TimerManager Instance { get; private set; }

    // public float gameDuration: ระยะเวลาของเกมเป็นวินาที (กำหนดใน Inspector)
    public float gameDuration = 60f; // 60 วินาที = 1 นาที
    private float currentTime; // เวลาปัจจุบันที่เหลือ

    [SerializeField] private TextMeshProUGUI timerTextUI; // UI Text แสดงเวลา

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject); // ไม่จำเป็นต้องใช้สำหรับ TimerManager เพราะจะอยู่ใน Scene Gameplay เท่านั้น
        }
    }

    private void Start()
    {
        currentTime = gameDuration; // กำหนดเวลาเริ่มต้น
        UpdateTimeUI(); // อัปเดต UI ครั้งแรก
        Time.timeScale = 1f; // ตรวจสอบให้แน่ใจว่าเวลาในเกมเดินปกติเมื่อเริ่ม
        // ซ่อนเมาส์และล็อกไว้กลางจอเมื่อเริ่มเกม
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // ลดเวลาลงทุกเฟรม
            UpdateTimeUI(); // อัปเดต UI

            if (currentTime <= 0 && InventoryManager.Instance != null)
            {
                // ถ้าเวลาหมด และยังไม่ชนะ (คือไม่ได้เก็บของครบ)
                // (ตรวจสอบว่า InventoryManager.Instance.batteryCount < InventoryManager.Instance.batteriesToWin)
                // แต่ในโค้ดนี้ เราจะให้ InventoryManager ตัดสินใจเองว่าชนะหรือแพ้จากเงื่อนไขของมัน
                // TimerManager จะเรียก LoseGame() เมื่อเวลาหมดเท่านั้น ถ้ายังไม่ชนะ
                InventoryManager.Instance.LoseGame(); // สั่งให้ InventoryManager บอกว่าแพ้เกม
            }
        }
    }

    // อัปเดต UI แสดงเวลา
    private void UpdateTimeUI()
    {
        if (timerTextUI != null)
        {
            // แปลงเวลาเป็นรูปแบบ นาที:วินาที (เช่น 01:30)
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            timerTextUI.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
        }
    }

    // ฟังก์ชันที่อาจจะใช้เมื่อเกมจบ (เช่น กลับไปหน้าเมนูหลัก)
    public void RestartGame()
    {
        // Unload current scene and load MainMenu
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}