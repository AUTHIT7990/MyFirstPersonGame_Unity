using UnityEngine;
using TMPro; // สำหรับใช้ TextMeshProUGUI

// InventoryManager : MonoBehaviour
public class InventoryManager : MonoBehaviour
{
    // public static InventoryManager Instance: นี่คือส่วนที่ทำให้เป็น Singleton Pattern
    // Instance จะเก็บ Reference ไปยัง InventoryManager ตัวเดียวใน Scene
    public static InventoryManager Instance { get; private set; }

    // int batteryCount: ตัวแปรเก็บจำนวนแบตเตอรี่ที่เก็บได้
    private int batteryCount = 0;
    // TextMeshProUGUI batteryCountText: อ้างอิงถึง UI Text ที่จะแสดงจำนวนแบตเตอรี่
    [SerializeField] private TextMeshProUGUI batteryCountText;
    // TextMeshProUGUI latestCollectedText: อ้างอิงถึง UI Text ที่จะแสดง Item ล่าสุดที่เก็บได้
    [SerializeField] private TextMeshProUGUI latestCollectedText;

    // Awake() จะถูกเรียกก่อน Start()
    // เหมาะสำหรับตั้งค่า Singleton Instance
    private void Awake()
    {
        // ตรวจสอบว่ามี Instance อื่นอยู่แล้วหรือไม่
        if (Instance != null && Instance != this)
        {
            // ถ้ามีอยู่แล้ว ให้ทำลาย GameObject นี้ (ป้องกันมี InventoryManager ซ้ำ)
            Destroy(gameObject);
        }
        else
        {
            // ถ้ายังไม่มี ให้กำหนด Instance เป็น GameObject นี้
            Instance = this;
            // Don't destroy this object when loading new scenes (เพื่อให้ Inventory คงอยู่ข้าม Scene)
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start() จะถูกเรียกเมื่อ Script เริ่มทำงาน
    private void Start()
    {
        UpdateBatteryCountUI(); // อัปเดต UI เมื่อเริ่มเกม
        latestCollectedText.text = ""; // ล้างข้อความ Item ล่าสุดเมื่อเริ่ม
    }

    // public void AddBattery(): ฟังก์ชันเพิ่มแบตเตอรี่
    public void AddBattery()
    {
        batteryCount++; // เพิ่มจำนวนแบตเตอรี่
        UpdateBatteryCountUI(); // อัปเดต UI
        ShowCollectedItemMessage("Battery"); // แสดงข้อความเก็บ Item
    }

    // private void UpdateBatteryCountUI(): อัปเดตข้อความ UI จำนวนแบตเตอรี่
    private void UpdateBatteryCountUI()
    {
        if (batteryCountText != null)
        {
            batteryCountText.text = "Batteries: " + batteryCount;
        }
    }

    // private void ShowCollectedItemMessage(string itemName): แสดงข้อความ Item ล่าสุดที่เก็บได้
    private void ShowCollectedItemMessage(string itemName)
    {
        if (latestCollectedText != null)
        {
            latestCollectedText.text = "Collected: " + itemName;
            // Invoke("ClearCollectedItemMessage", 2f): เรียกฟังก์ชัน ClearCollectedItemMessage หลังจาก 2 วินาที
            Invoke("ClearCollectedItemMessage", 2f);
        }
    }

    // private void ClearCollectedItemMessage(): ล้างข้อความ Item ล่าสุดที่เก็บได้
    private void ClearCollectedItemMessage()
    {
        if (latestCollectedText != null)
        {
            latestCollectedText.text = "";
        }
    }
}