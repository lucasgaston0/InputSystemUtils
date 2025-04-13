using games.noio.InputHints;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystemUtils
{
    [RequireComponent(typeof(PlayerInput))]
    public class DeviceDetector : MonoBehaviour
    {
        PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        private void OnEnable()
        {
            _playerInput.onControlsChanged += OnControlsChanged; 
        }

        private void OnDisable()
        {
            _playerInput.onControlsChanged -= OnControlsChanged;
        }

        private void OnControlsChanged(PlayerInput obj)
        {
            InputHints.SetUsedDevice(obj.devices[0]);
        }
    }
}
