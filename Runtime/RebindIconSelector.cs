using games.noio.InputHints;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace InputSystemUtils
{
    public class RebindIconSelector : MonoBehaviour
    {
        [SerializeField] InputHintsConfig _source;

        protected void OnEnable()
        {
            // Hook into all updateBindingUIEvents on all RebindActionUI components in our hierarchy.
            var rebindUIComponents = transform.GetComponentsInChildren<RebindActionUI>();
            foreach (var component in rebindUIComponents)
            {
                component.updateBindingUIEvent.AddListener(OnUpdateBindingDisplay);
                component.UpdateBindingDisplay();
            }
        }

        protected void OnUpdateBindingDisplay(RebindActionUI component, string bindingDisplayString, string deviceLayoutName, string controlPath)
        {
            if (string.IsNullOrEmpty(deviceLayoutName) || string.IsNullOrEmpty(controlPath))
                return;

            var textComponent = component.bindingText;
            string spriteString;

            if (InputSystem.IsFirstLayoutBasedOnSecond(deviceLayoutName, "Gamepad"))
            {
                spriteString = _source.GetSprite(component.actionReference.action, true);
            }
            else
            {
                spriteString = _source.GetSprite(component.actionReference.action, false);
            }

            if (!string.IsNullOrEmpty(spriteString))
            {
                textComponent.text = spriteString;
            }
        }
    }
}
