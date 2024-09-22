using FSM.Hash;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;

public class HashFSMEditor : EditorWindow
{


    private const string UXML_PATH_ROOT = "Assets/07_ToolKit/FSM/Hash/";

    private MainWindowElement _window;
    private HashFSMRouteMap _target;

    private void SetUp()
    {

        _window = new MainWindowElement(rootVisualElement);

        //SetUp States
        {

            foreach (var item in _target.states)
                _window.AddState(item);

        }


        _window.OnStateCreated += HandleStateCreated;

    }

    private void HandleStateCreated(string stateName)
    {

        _target.states.Add(stateName);
        SetDirt(_target);

    }

    private void SetDirt(ScriptableObject obj) => EditorUtility.SetDirty(obj);

    [OnOpenAsset]
    public static bool OnOpenAsset(int instanceID, int line)
    {

        if(Selection.activeObject is HashFSMRouteMap obj)
        {

            var window = CreateWindow<HashFSMEditor>(obj.name);
            window._target = obj;

            window.SetUp();

            return true;

        }

        return false;

    }

    private class MainWindowElement
    {

        /// <summary>
        /// 현재 스테이트들이 보이는 필드
        /// </summary>
        private DropdownField _statesField;

        /// <summary>
        /// 스테이트 이름 생성할 때 이름 입력하는 필드
        /// </summary>
        private TextField _stateNameField;

        /// <summary>
        /// 스테이트 만들 때 클릭하는 버튼
        /// </summary>
        private Button _createStateButton;

        /// <summary>
        /// 현재 스테이트 라벨
        /// </summary>
        private Label _currentStateLabel;

        /// <summary>
        /// 바인딩할 state클래스를 선택하는 필드
        /// </summary>
        private DropdownField _bindStateField;

        public event Action<string> OnSelectStateChanged;
        public event Action<string> OnClassSelectChanged;
        public event Action<string> OnStateCreated;

        public MainWindowElement(VisualElement root)
        {

            var ins = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(UXML_PATH_ROOT + "HashFSMEditor.uxml");
            VisualElement obj = ins.Instantiate();

            root.Add(obj);

            Binding(obj);

        }

        private void Binding(VisualElement obj)
        {

            _statesField = obj.Q<DropdownField>("StatesField");
            _stateNameField = obj.Q<TextField>("StateNameField");
            _createStateButton = obj.Q<VisualElement>("AddState").Q<Button>("AddButton");
            _currentStateLabel = obj.Q<Label>("CurrentStateText");
            _bindStateField = obj.Q<DropdownField>("BindStateField");

            _createStateButton.clicked += HandleCreateState;
            _statesField.RegisterValueChangedCallback(HandleSelectStateChange);
            _bindStateField.RegisterValueChangedCallback(HandleSelectClassChange);

        }

        private void HandleSelectClassChange(ChangeEvent<string> evt)
        {

            OnClassSelectChanged?.Invoke(evt.newValue);

        }

        private void HandleSelectStateChange(ChangeEvent<string> evt)
        {

            _currentStateLabel.text = evt.newValue;
            OnSelectStateChanged?.Invoke(evt.newValue);

        }

        private void HandleCreateState()
        {

            var name = _stateNameField.value;

            _statesField.choices.Add(name);

            OnStateCreated?.Invoke(name);

        }

        /// <summary>
        /// 바인딩할 클래스를 추가
        /// </summary>
        /// <param name="name">클래스 이름</param>
        public void AddBindingClass(string name)
        {

            _bindStateField.choices.Add(name);

        }

        public void AddState(string name)
        {

            _statesField.choices.Add(name);

        }

    }

}