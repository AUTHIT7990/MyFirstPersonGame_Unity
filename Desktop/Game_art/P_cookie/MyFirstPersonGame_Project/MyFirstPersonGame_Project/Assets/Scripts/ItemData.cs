using UnityEngine; // บรรทัดนี้มีอยู่แล้ว

// [CreateAssetMenu(...)]: Attribute นี้จะสร้างเมนูใน Unity Editor ให้เราสามารถสร้าง Asset จาก Script นี้ได้
// fileName: ชื่อไฟล์เริ่มต้นเมื่อสร้าง Asset ใหม่
// menuName: ตำแหน่งเมนูที่จะปรากฏ (เช่น Create/Item Data)
// order: ลำดับในเมนู
[CreateAssetMenu(fileName = "NewItemData", menuName = "Inventory/Item Data", order = 1)]
// public class ItemData : ScriptableObject: คลาสนี้สืบทอดจาก ScriptableObject
// ทำให้สามารถสร้างเป็น Asset ไฟล์แยกใน Project ได้ และเก็บข้อมูลได้โดยไม่ต้องติดกับ GameObject
public class ItemData : ScriptableObject
{
    // public string itemName: ชื่อ Item
    public string itemName = "New Item";
    // [TextArea]: แสดงผลเป็นช่องข้อความหลายบรรทัดใน Inspector
    // public string description: รายละเอียด Item
    [TextArea(3, 5)] // 3-5 บรรทัด
    public string description = "Default item description.";
    // public Sprite icon: รูป Icon ของ Item
    public Sprite icon;
    // public GameObject prefab: Prefab ของ Item (เช่น โมเดล 3D)
    public GameObject prefab;
}