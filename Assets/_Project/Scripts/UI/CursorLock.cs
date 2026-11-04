using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjetoLuz.UI
{
    public sealed class CursorLock : MonoBehaviour
    {
        [SerializeField] private InputActionReference _unlock;
        [SerializeField] private InputActionReference _lock;

        private void OnEnable()
        {
            _unlock.action.Enable();
            _lock.action.Enable();
            _unlock.action.performed += OnUnlockPerformed;
            _lock.action.performed += OnLockPerformed;
            Lock();
        }

        private void OnDisable()
        {
            _unlock.action.performed -= OnUnlockPerformed;
            _lock.action.performed -= OnLockPerformed;
            Unlock();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
                Unlock();
        }

        private void OnUnlockPerformed(InputAction.CallbackContext context)
        {
            Unlock();
        }

        private void OnLockPerformed(InputAction.CallbackContext context)
        {
            Lock();
        }

        private static void Lock()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private static void Unlock()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
