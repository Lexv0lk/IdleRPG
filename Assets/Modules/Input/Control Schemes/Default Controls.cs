//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Modules/Input/Control Schemes/Default Controls.inputactions
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

public partial class @DefaultControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @DefaultControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Default Controls"",
    ""maps"": [
        {
            ""name"": ""Character Map"",
            ""id"": ""9bc75c5a-313b-4b1a-9976-f7eff440e6ae"",
            ""actions"": [
                {
                    ""name"": ""Move Action"",
                    ""type"": ""Value"",
                    ""id"": ""acf5e598-2ad2-49ec-be3d-9e36cbd727b7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""MouseSwipe"",
                    ""id"": ""05c289c1-d531-48d6-b3b2-031058bb6b34"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Action"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""23c6b5fe-f09e-42eb-ac51-d8e131cb2e14"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""db4d3e2b-b022-441a-96f8-5229153e0f4f"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""TouchSwipe"",
                    ""id"": ""894ed997-7656-4002-af1a-c288360d2697"",
                    ""path"": ""OneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Action"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""31c62b81-0b69-4900-8e54-ee3b017d4870"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""binding"",
                    ""id"": ""40dd9a98-de2a-4f00-abd6-c67c52e63936"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": []
        }
    ]
}");
        // Character Map
        m_CharacterMap = asset.FindActionMap("Character Map", throwIfNotFound: true);
        m_CharacterMap_MoveAction = m_CharacterMap.FindAction("Move Action", throwIfNotFound: true);
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

    // Character Map
    private readonly InputActionMap m_CharacterMap;
    private List<ICharacterMapActions> m_CharacterMapActionsCallbackInterfaces = new List<ICharacterMapActions>();
    private readonly InputAction m_CharacterMap_MoveAction;
    public struct CharacterMapActions
    {
        private @DefaultControls m_Wrapper;
        public CharacterMapActions(@DefaultControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveAction => m_Wrapper.m_CharacterMap_MoveAction;
        public InputActionMap Get() { return m_Wrapper.m_CharacterMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterMapActions set) { return set.Get(); }
        public void AddCallbacks(ICharacterMapActions instance)
        {
            if (instance == null || m_Wrapper.m_CharacterMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CharacterMapActionsCallbackInterfaces.Add(instance);
            @MoveAction.started += instance.OnMoveAction;
            @MoveAction.performed += instance.OnMoveAction;
            @MoveAction.canceled += instance.OnMoveAction;
        }

        private void UnregisterCallbacks(ICharacterMapActions instance)
        {
            @MoveAction.started -= instance.OnMoveAction;
            @MoveAction.performed -= instance.OnMoveAction;
            @MoveAction.canceled -= instance.OnMoveAction;
        }

        public void RemoveCallbacks(ICharacterMapActions instance)
        {
            if (m_Wrapper.m_CharacterMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICharacterMapActions instance)
        {
            foreach (var item in m_Wrapper.m_CharacterMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CharacterMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CharacterMapActions @CharacterMap => new CharacterMapActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface ICharacterMapActions
    {
        void OnMoveAction(InputAction.CallbackContext context);
    }
}
