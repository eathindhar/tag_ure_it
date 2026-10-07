using UnityEngine;
using UnityEngine.EventSystems;

namespace TarodevController
{
    /// <summary>
    /// Attach to a UI Button (or any UI Graphic with Raycast Target on) to feed
    /// Left/Right/Jump input into PlayerController while pressed and held.
    /// Works with both mouse clicks and touch, since it goes through Unity's
    /// EventSystem rather than reading Input directly.
    /// </summary>
    public class MobileInputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private enum ButtonType { Left, Right, Jump }

        [SerializeField] private ButtonType _type;
        [SerializeField] private PlayerController _player;

        public void OnPointerDown(PointerEventData eventData)
        {
            switch (_type)
            {
                case ButtonType.Left:
                    _player.SetUILeftHeld(true);
                    break;
                case ButtonType.Right:
                    _player.SetUIRightHeld(true);
                    break;
                case ButtonType.Jump:
                    _player.SetUIJumpHeld(true);
                    break;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            switch (_type)
            {
                case ButtonType.Left:
                    _player.SetUILeftHeld(false);
                    break;
                case ButtonType.Right:
                    _player.SetUIRightHeld(false);
                    break;
                case ButtonType.Jump:
                    _player.SetUIJumpHeld(false);
                    break;
            }
        }

        private void OnDisable()
        {
            // Safety net: if the button is disabled/destroyed mid-press (e.g. pausing,
            // scene changes), make sure we don't leave an input stuck "on".
            switch (_type)
            {
                case ButtonType.Left:
                    if (_player) _player.SetUILeftHeld(false);
                    break;
                case ButtonType.Right:
                    if (_player) _player.SetUIRightHeld(false);
                    break;
                case ButtonType.Jump:
                    if (_player) _player.SetUIJumpHeld(false);
                    break;
            }
        }
    }
}
