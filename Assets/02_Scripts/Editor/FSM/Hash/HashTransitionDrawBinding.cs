using FSM.Hash;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public delegate void HashDraw(Rect position, SerializedProperty property, 
    int currentStateIdx, ref float totalHeight);


public static class HashTransitionDrawBinding
{

    private static Dictionary<Type, DrawObject> _bindContainer = new()
    {

        {
            typeof(int),
            new DefaultDraw()
        }

    };

    public static HashDraw GetBindDraw(Type t)
    {

        if (_bindContainer.TryGetValue(t, out DrawObject drawObject))
            return drawObject.Draw;

        return _bindContainer[typeof(int)].Draw;

    }

    private abstract class DrawObject
    {
        public abstract void Draw(Rect position, SerializedProperty property, int currentStateIdx, ref float totalHeight);

        protected SerializedProperty GetTransitonsField(SerializedProperty property, int idx)
            => property.FindPropertyRelative("transitions").GetArrayElementAtIndex(idx);
        protected void AddLabel(Rect position, string text, ref float totalHeight)
        {

            var pos = GetPositon(position, new Vector2(0, totalHeight));
            EditorGUI.LabelField(pos, text);

            totalHeight += 20;

        }

        protected Rect GetPositon(Rect position, Vector2 povit)
        {

            return new Rect(position.position + povit, new Vector2(position.size.x, 18));

        }

    }

    private class DefaultDraw : DrawObject
    {
        private TypeCache.TypeCollection _findTypes;
        private List<string> _displays;
        private int _stateObjectSelect;
        private bool _transitonFoldout;

        public override void Draw(Rect position, SerializedProperty property, int currentStateIdx, ref float totalHeight)
        {

            if (!TransitoinFoldout(position, ref totalHeight))
                return;

            position.x += 20;
            position.width -= 20;

            AddTransition(position, property, ref totalHeight);

            //var t_field = GetTransitonsField(property, currentStateIdx);
            //int size = t_field.arraySize;

            //for(int i = 0; i < size; i++)
            //{



            //}

        }

        private bool TransitoinFoldout(Rect position, ref float totalHeight)
        {

            _transitonFoldout = EditorGUI.Foldout(GetPositon(position, new Vector2(0, totalHeight)), _transitonFoldout, "Transitoins");
            totalHeight += 20;
            return _transitonFoldout;

        }

        private void AddTransition(Rect position, SerializedProperty property, ref float totalHeight)
        {

            position.width /= 2;

            //DropDown
            {

                _findTypes = TypeCache.GetTypesDerivedFrom<HashTransitionBase>();
                _displays = new List<string>();

                foreach (var item in _findTypes)
                {

                    if (item.IsAbstract)
                        continue;

                    _displays.Add(item.Name);

                }

                _stateObjectSelect =
                    EditorGUI.Popup(GetPositon(position, new Vector2(0, totalHeight)),
                    _stateObjectSelect, _displays.ToArray());

            }

            //AddBtn
            {

                if(GUI.Button(GetPositon(position, new Vector2(position.width, totalHeight)), "AddTransiton"))
                {


                }

            }
            

            totalHeight += 20;

        }
    }

}
