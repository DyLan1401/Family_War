using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileControls : MonoBehaviour
{
    // Kéo PlayerController vào ?ây
    public PlayerController playerController;

    // Tr?ng thái nút ?ang gi?
    [HideInInspector] public bool isPressingLeft = false;
    [HideInInspector] public bool isPressingRight = false;

    // G?n vào nút Trái
    public void OnLeftDown() { isPressingLeft = true; }
    public void OnLeftUp() { isPressingLeft = false; }

    // G?n vào nút Ph?i
    public void OnRightDown() { isPressingRight = true; }
    public void OnRightUp() { isPressingRight = false; }

    // G?n vào nút Nh?y
    public void OnJump() { playerController.MobileJump(); }

    // G?n vào nút T?n công
    public void OnAttack() { playerController.MobileAttack(); }
}