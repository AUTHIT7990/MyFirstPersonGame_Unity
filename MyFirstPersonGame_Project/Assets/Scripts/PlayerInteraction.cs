using UnityEngine; // บรรทัดนี้มีอยู่แล้ว
using UnityEngine.InputSystem; // เพิ่มบรรทัดนี้: สำหรับรับ Input ใหม่ของ Unity
using TMPro; // เพิ่มบรรทัดนี้: สำหรับใช้ TextMeshPro ในการแสดงข้อความ UI

// PlayerInteraction : MonoBehaviour: คลาสนี้สืบทอดจาก MonoBehaviour
public class PlayerInteraction : MonoBehaviour
{
    // SerializeField: ทำให้ตัวแปร private แสดงใน Inspector [cite: 324]
    // Transform cameraTransform: อ้างอิงถึง Transform ของกล้อง (เพื่อให้รู้ว่า Raycast จะยิงมาจากไหน)
    [SerializeField] private Transform cameraTransform;
    // float interactionDistance: ระยะห่างสูงสุดที่สามารถ Interact ได้ [cite: 451]
    [SerializeField] private float interactionDistance = 3f;
    // LayerMask interactionLayerMask: Layer ที่ Raycast จะชน (เพื่อกรองไม่ให้ชนวัตถุที่ไม่ต้องการ) [cite: 451]
    [SerializeField] private LayerMask interactionLayerMask;
    // TextMeshProUGUI interactionTextUI: อ้างอิงถึง UI Text ที่จะแสดงข้อความ Interact
    [SerializeField] private TextMeshProUGUI interactionTextUI;

    // ตัวแปรสำหรับเก็บ IInteractable ที่มองเห็นอยู่
    private IInteractable currentInteractable;

    // OnEnable: ถูกเรียกเมื่อ GameObject หรือ Script ถูกเปิดใช้งาน [cite: 286]
    // เหมาะสำหรับลงทะเบียน Event
    private void OnEnable()
    {
        // หากมี InputSystem ให้ลงทะเบียนการกดปุ่ม 'E'
        // InputSystem.onDeviceChange += OnDeviceChange; // อาจไม่จำเป็นต้องใช้ในกรณีนี้
    }

    // OnDisable: ถูกเรียกเมื่อ GameObject หรือ Script ถูกปิดใช้งาน [cite: 294]
    // เหมาะสำหรับยกเลิกการลงทะเบียน Event เพื่อป้องกัน Memory Leak [cite: 294]
    private void OnDisable()
    {
        // ยกเลิกการลงทะเบียน Event หากเคยลงทะเบียน
    }

    // Update is called once per frame
    void Update()
    {
        // Reset ค่าการมองเห็น
        currentInteractable = null;
        interactionTextUI.text = ""; // ล้างข้อความบน UI

        // Raycast จากตำแหน่งกล้องไปข้างหน้า
        // Physics.Raycast(): ยิง Raycast และส่งคืน true ถ้าชนวัตถุ [cite: 451]
        // out RaycastHit hit: เก็บข้อมูลของวัตถุที่ชน [cite: 451]
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, interactionDistance, interactionLayerMask))
        {
            // Debug.DrawRay(): วาด Raycast ใน Scene View เพื่อการ Debug [cite: 454]
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * interactionDistance, Color.green);

            // พยายามดึง Component ที่ใช้ Interface IInteractable จากวัตถุที่ชน
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null) // ถ้าพบ Component ที่ใช้ IInteractable
            {
                currentInteractable = interactable; // เก็บ reference ไว้
                interactionTextUI.text = currentInteractable.GetInteractionText(); // แสดงข้อความบน UI
            }
        }
        else
        {
            Debug.DrawRay(cameraTransform.position, cameraTransform.forward * interactionDistance, Color.red); // วาด Raycast เป็นสีแดงเมื่อไม่ชนอะไร
        }
    }

    // ฟังก์ชันสำหรับรับ Input จากปุ่ม Interact (จะผูกกับ Action "Interact" ใน Input System)
    // context: ข้อมูลการกดปุ่ม
    public void OnInteract(InputAction.CallbackContext context)
    {
        // ตรวจสอบว่าปุ่มถูกกดลงไปจริงๆ (ไม่ใช่ตอนปล่อย) และมี Item ที่ Interact ได้อยู่ในระยะ
        if (context.performed && currentInteractable != null)
        {
            currentInteractable.Interact(); // เรียกฟังก์ชัน Interact ของ Item นั้น
        }
    }
}