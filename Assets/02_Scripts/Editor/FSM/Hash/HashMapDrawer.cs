using FSM.Hash;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(HashFSMRouteMap))]
public class HashMapDrawer : PropertyDrawer
{

    private int _stateSelect;
    private string _createStateName;
    private float _totalHeight;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        _totalHeight = 0;

        EditorGUI.BeginProperty(position, label, property);

        StateSelectPopup(position, property);
        CreateStateField(position, property);
        DeleteStateBtn(position, property);
        BindStateField(position, property);

        EditorGUI.EndProperty();

    }

    private void BindStateField(Rect position, SerializedProperty property)
    {

        _totalHeight += 20;
        AddLabel(position, "BindState");

        //BindingDropDown
        {

            var types = TypeCache.GetTypesDerivedFrom<HashStateBase>();
            List<string> displays = new List<string>();

            foreach(var item in types)
            {

                //여기에 조건 추가


            }

        }

    }

    private void AddLabel(Rect position, string text)
    {

        var pos = GetPositon(position, new Vector2(0, _totalHeight));
        EditorGUI.LabelField(pos, text);

        _totalHeight += 20;

    }

    private void DeleteStateBtn(Rect position, SerializedProperty property)
    {

        var pos = GetPositon(position, new Vector2(0, _totalHeight));

        if (GUI.Button(pos, "DeleteState"))
        {

            var field = GetStatesField(property);
            field.DeleteArrayElementAtIndex(_stateSelect);

            _stateSelect = 0;

        }

        _totalHeight += 20;

    }

    private void StateSelectPopup(Rect position, SerializedProperty property)
    {

        AddLabel(position, "CurrentState");

        var pos = GetPositon(position, new Vector2(0, _totalHeight));

        var field = GetStatesField(property);
        var size = field.arraySize;
        string[] array = new string[size];

        for(int i = 0; i < size; i++)
        {
            array[i] = field.GetArrayElementAtIndex(i).stringValue;
        }

        _stateSelect = EditorGUI.Popup(pos, _stateSelect, array);

        _totalHeight += 20;

    }

    private void CreateStateField(Rect position, SerializedProperty property)
    {

        _totalHeight += 20;
        AddLabel(position, "ControlState");

        //TextField
        {
            EditorGUI.BeginChangeCheck();

            position.width /= 2;
            var pos = GetPositon(position, new Vector2(0, _totalHeight));

            var str = EditorGUI.TextField(pos, _createStateName);

            if (EditorGUI.EndChangeCheck())
            {

                _createStateName = str;

            }

        }

        //Button
        {

            var origin = position.width;
            position.width /= 2;

            var pos = GetPositon(position, new Vector2(origin * 1.5f, _totalHeight));

            if(GUI.Button(pos, "AddState"))
            {

                if (string.IsNullOrEmpty(_createStateName))
                    return;

                var states = GetStatesField(property);
                int idx = states.arraySize;
                states.InsertArrayElementAtIndex(idx);
                var elem = states.GetArrayElementAtIndex(idx);
                elem.stringValue = _createStateName;

                _createStateName = "";

            }

        }

        _totalHeight += 20;

    }

    private SerializedProperty GetStatesField(SerializedProperty property) => property.FindPropertyRelative("states");

    private Rect GetPositon(Rect position, Vector2 povit)
    {

        return new Rect(position.position + povit, new Vector2(position.size.x, 18));

    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {

        return _totalHeight;

    }


}
