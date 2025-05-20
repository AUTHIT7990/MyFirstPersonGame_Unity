using UnityEngine;
using UnityEngine.InputSystem; // สำหรับรับ Input ใหม่
using UnityEngine.SceneManagement; // สำหรับเปลี่ยน Scene

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    // เพิ่มตัวแปรสำหรับอ้างอิงถึง PlayerInputComponent
    [SerializeField] private PlayerInput playerInputComponent;

    private bool isPaused = false;

    private void Start()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // ปิดการทำงานของ PlayerInputComponent เมื่อหยุดเกม
        if (playerInputComponent != null)
        {
            playerInputComponent.enabled = false;
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
        Time.timeScale = 1f;
        Cursor.visible = false; // ซ่อนเมาส์เมื่อกลับมาเล่น
        Cursor.lockState = CursorLockMode.Locked; // ล็อกเมาส์ไว้กลางจอ

        // เปิดการทำงานของ PlayerInputComponent เมื่อเล่นต่อ
        if (playerInputComponent != null)
        {
            playerInputComponent.enabled = true;
        }
    }

    public void RestartGame()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }
}