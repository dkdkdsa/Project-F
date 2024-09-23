using FSM.Hash;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Reflection;

[CustomPropertyDrawer(typeof(HashFSMRouteMap))]
public class HashMapDrawer : PropertyDrawer
{

    private string _createStateName;
    private float _totalHeight;
    private int _stateSelect;
    private int _stateObjectSelect;
    private bool _bindStateFoldOut;
    private List<string> _displays;
    private TypeCache.TypeCollection _findTypes;

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


        if (string.IsNullOrEmpty(GetCurrentState(property)))
            return;

        _totalHeight += 20;
        _bindStateFoldOut = EditorGUI.Foldout(GetPositon(position, new Vector2(0, _totalHeight)), _bindStateFoldOut, "StateObject");
        _totalHeight += 20;

        if (!_bindStateFoldOut)
            return;

        position.x += 20;
        position.width -= 20;

        //BindingDropDown
        {

            _findTypes = TypeCache.GetTypesDerivedFrom<HashStateBase>();
            _displays = new List<string>() { "None" };

            foreach(var item in _findTypes)
            {

                if (item.IsAbstract)
                    continue;

                _displays.Add(item.Name);

            }

            var obj = GetStatesObjectsField(property).GetArrayElementAtIndex(_stateSelect).objectReferenceValue;

            _stateObjectSelect = obj == null ? 0 : _displays.FindIndex(x => x == obj.GetType().Name);

            _stateObjectSelect =
                EditorGUI.Popup(GetPositon(position, new Vector2(0, _totalHeight)), 
                _stateObjectSelect, _displays.ToArray());

            _totalHeight += 20;

        }

        //CheckCreate
        {

            var field = GetStatesObjectsField(property);

            if (_displays[_stateObjectSelect] != "None" 
                && 
                field.GetArrayElementAtIndex(_stateSelect).objectReferenceValue == null)
            {

                var t = _findTypes.First(x => x.Name == _displays[_stateObjectSelect]);
                var ins = (property.serializedObject.targetObject as MonoBehaviour).gameObject.AddComponent(t);

                ins.hideFlags = HideFlags.HideInInspector;

                field.GetArrayElementAtIndex(_stateSelect).objectReferenceValue = ins;
                field.GetArrayElementAtIndex(_stateSelect).serializedObject.ApplyModifiedProperties();

            }

        }

        //CheckDestroy
        {

            var field = GetStatesObjectsField(property);
            var obj = field.GetArrayElementAtIndex(_stateSelect).objectReferenceValue;

            if (obj == null)
                return;

            if (_displays[_stateObjectSelect] != obj.GetType().Name)
            {

                UnityEngine.Object.DestroyImmediate(obj);

            }

        }

        //DrawBindingObject
        {

            var field = GetStatesObjectsField(property);

            if (_displays[_stateObjectSelect] != "None"
                &&
                field.GetArrayElementAtIndex(_stateSelect).objectReferenceValue != null)
            {

                var obj = new SerializedObject(field.GetArrayElementAtIndex(_stateSelect).objectReferenceValue);

                EditorGUI.BeginChangeCheck();
                obj.UpdateIfRequiredOrScript();
                SerializedProperty iterator = obj.GetIterator();
                bool enterChildren = true;
                while (iterator.NextVisible(enterChildren))
                {
                    using (new EditorGUI.DisabledScope("m_Script" == iterator.propertyPath))
                    {
                        EditorGUI.PropertyField(GetPositon(position, new Vector2(0, _totalHeight)), iterator, true);
                        _totalHeight += 20;
                    }

                    enterChildren = false;
                }

                obj.ApplyModifiedProperties();
                EditorGUI.EndChangeCheck();

            }

        }

        //DrawTransitonData
        {

            var obj = GetStatesObjectsField(property).GetArrayElementAtIndex(_stateSelect).objectReferenceValue as HashStateBase;

            if(obj == null) 
                return;

            var v = HashTransitionDrawBinding.GetBindDraw(obj.GetType());
            v(position, property, _stateSelect, ref _totalHeight);

        }


    }

    private string GetCurrentState(SerializedProperty property)
    {

        var field = GetStatesField(property);

        return field.arraySize > 0 ? 
            field.GetArrayElementAtIndex(_stateSelect).stringValue
            :
            null;

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
            var objects = GetStatesObjectsField(property);

            field.DeleteArrayElementAtIndex(_stateSelect);
            objects.DeleteArrayElementAtIndex(_stateSelect);

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
                var objects = GetStatesObjectsField(property);

                int idx = states.arraySize;
                states.InsertArrayElementAtIndex(idx);

                objects.InsertArrayElementAtIndex(idx);
                objects.GetArrayElementAtIndex(idx).objectReferenceValue = null;

                var elem = states.GetArrayElementAtIndex(idx);
                elem.stringValue = _createStateName;

                _createStateName = "";

            }

        }

        _totalHeight += 20;

    }

    private SerializedProperty GetStatesField(SerializedProperty property) => property.FindPropertyRelative("states");
    private SerializedProperty GetStatesObjectsField(SerializedProperty property) => property.FindPropertyRelative("stateObjects");

    private Rect GetPositon(Rect position, Vector2 povit)
    {

        return new Rect(position.position + povit, new Vector2(position.size.x, 18));

    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {

        return _totalHeight;

    }


}
