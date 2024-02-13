//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/InputSystem/InputMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMap"",
    ""maps"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""id"": ""83cb7c7d-dab1-4721-b5fc-6a0acc2ee11b"",
            ""actions"": [
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3a184e34-fa9d-4969-a3b7-d2abdc170b47"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6674a977-0f33-4ddc-a1bb-0fb0f8259052"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Touchscreen"",
            ""id"": ""6f1c9ef2-006f-4ad7-bae7-f5f5983904e8"",
            ""actions"": [
                {
                    ""name"": ""TouchDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dcfdcd47-5507-47c3-ab5b-a39b4062e3f1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""4a786481-774f-4b63-a0f2-f2fcb7db588d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""44339568-6e9b-404b-af3f-8d41fe09b697"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e8b4f937-6aa3-46c6-9617-39d4bb8e1bf7"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""451cd923-3326-4100-af8d-fa2d520aa40c"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""451f5a72-37fe-4ef0-8269-94560f9942d6"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // KeyboardAndMouse
        m_KeyboardAndMouse = asset.FindActionMap("KeyboardAndMouse", throwIfNotFound: true);
        m_KeyboardAndMouse_MouseDelta = m_KeyboardAndMouse.FindAction("MouseDelta", throwIfNotFound: true);
        // Touchscreen
        m_Touchscreen = asset.FindActionMap("Touchscreen", throwIfNotFound: true);
        m_Touchscreen_TouchDelta = m_Touchscreen.FindAction("TouchDelta", throwIfNotFound: true);
        m_Touchscreen_TouchPress = m_Touchscreen.FindAction("TouchPress", throwIfNotFound: true);
        m_Touchscreen_TouchPosition = m_Touchscreen.FindAction("TouchPosition", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // KeyboardAndMouse
    private readonly InputActionMap m_KeyboardAndMouse;
    private List<IKeyboardAndMouseActions> m_KeyboardAndMouseActionsCallbackInterfaces = new List<IKeyboardAndMouseActions>();
    private readonly InputAction m_KeyboardAndMouse_MouseDelta;
    public struct KeyboardAndMouseActions
    {
        private @InputMap m_Wrapper;
        public KeyboardAndMouseActions(@InputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseDelta => m_Wrapper.m_KeyboardAndMouse_MouseDelta;
        public InputActionMap Get() { return m_Wrapper.m_KeyboardAndMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardAndMouseActions set) { return set.Get(); }
        public void AddCallbacks(IKeyboardAndMouseActions instance)
        {
            if (instance == null || m_Wrapper.m_KeyboardAndMouseActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_KeyboardAndMouseActionsCallbackInterfaces.Add(instance);
            @MouseDelta.started += instance.OnMouseDelta;
            @MouseDelta.performed += instance.OnMouseDelta;
            @MouseDelta.canceled += instance.OnMouseDelta;
        }

        private void UnregisterCallbacks(IKeyboardAndMouseActions instance)
        {
            @MouseDelta.started -= instance.OnMouseDelta;
            @MouseDelta.performed -= instance.OnMouseDelta;
            @MouseDelta.canceled -= instance.OnMouseDelta;
        }

        public void RemoveCallbacks(IKeyboardAndMouseActions instance)
        {
            if (m_Wrapper.m_KeyboardAndMouseActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IKeyboardAndMouseActions instance)
        {
            foreach (var item in m_Wrapper.m_KeyboardAndMouseActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_KeyboardAndMouseActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public KeyboardAndMouseActions @KeyboardAndMouse => new KeyboardAndMouseActions(this);

    // Touchscreen
    private readonly InputActionMap m_Touchscreen;
    private List<ITouchscreenActions> m_TouchscreenActionsCallbackInterfaces = new List<ITouchscreenActions>();
    private readonly InputAction m_Touchscreen_TouchDelta;
    private readonly InputAction m_Touchscreen_TouchPress;
    private readonly InputAction m_Touchscreen_TouchPosition;
    public struct TouchscreenActions
    {
        private @InputMap m_Wrapper;
        public TouchscreenActions(@InputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchDelta => m_Wrapper.m_Touchscreen_TouchDelta;
        public InputAction @TouchPress => m_Wrapper.m_Touchscreen_TouchPress;
        public InputAction @TouchPosition => m_Wrapper.m_Touchscreen_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_Touchscreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchscreenActions set) { return set.Get(); }
        public void AddCallbacks(ITouchscreenActions instance)
        {
            if (instance == null || m_Wrapper.m_TouchscreenActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TouchscreenActionsCallbackInterfaces.Add(instance);
            @TouchDelta.started += instance.OnTouchDelta;
            @TouchDelta.performed += instance.OnTouchDelta;
            @TouchDelta.canceled += instance.OnTouchDelta;
            @TouchPress.started += instance.OnTouchPress;
            @TouchPress.performed += instance.OnTouchPress;
            @TouchPress.canceled += instance.OnTouchPress;
            @TouchPosition.started += instance.OnTouchPosition;
            @TouchPosition.performed += instance.OnTouchPosition;
            @TouchPosition.canceled += instance.OnTouchPosition;
        }

        private void UnregisterCallbacks(ITouchscreenActions instance)
        {
            @TouchDelta.started -= instance.OnTouchDelta;
            @TouchDelta.performed -= instance.OnTouchDelta;
            @TouchDelta.canceled -= instance.OnTouchDelta;
            @TouchPress.started -= instance.OnTouchPress;
            @TouchPress.performed -= instance.OnTouchPress;
            @TouchPress.canceled -= instance.OnTouchPress;
            @TouchPosition.started -= instance.OnTouchPosition;
            @TouchPosition.performed -= instance.OnTouchPosition;
            @TouchPosition.canceled -= instance.OnTouchPosition;
        }

        public void RemoveCallbacks(ITouchscreenActions instance)
        {
            if (m_Wrapper.m_TouchscreenActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITouchscreenActions instance)
        {
            foreach (var item in m_Wrapper.m_TouchscreenActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TouchscreenActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TouchscreenActions @Touchscreen => new TouchscreenActions(this);
    public interface IKeyboardAndMouseActions
    {
        void OnMouseDelta(InputAction.CallbackContext context);
    }
    public interface ITouchscreenActions
    {
        void OnTouchDelta(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
}
