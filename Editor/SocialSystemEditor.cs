using System.Linq;
using Audune.Utils.Types;
using Audune.Utils.Types.Editor;
using Audune.Utils.UnityEditor.Editor;
using UnityEditor;
using UnityEngine;

namespace Audune.Social.Editor
{
  /// <summary>
  /// Class that defines an editor for the social system.
  /// </summary>
  [CustomEditor(typeof(SocialSystem))]
  public class SocialSystemEditor : UnityEditor.Editor
  {
    // Foldout state of the editor
    private bool _socialProvidersFoldout = true;
    private bool _componentsFoldout = true;

    // Generic menus for types
    private GenericMenu _socialProvidersTypesMenu;


    // Return the target object of the editor
    public new SocialSystem target => serializedObject.targetObject as SocialSystem;


    // OnEnable is called when the component becomes enabled
    protected void OnEnable()
    {
      // Initialize the generic menus for types
      _socialProvidersTypesMenu = typeof(SocialProvider).CreateGenericMenuForChildTypes(TypeDisplayOptions.DontShowNamespace, null,
        type => {
          if (target.GetComponent(type) == null)
          {
            target.gameObject.AddComponent(type);
          }
          else
          {
            EditorUtility.DisplayDialog("Social System",
              $"The social system already contains a social provider of type {type.ToDisplayString(TypeDisplayOptions.DontShowNamespace)}.",
              "OK");
          }
        });
    }

    // Draw the inspector GUI
    public override void OnInspectorGUI()
    {
      serializedObject.Update();
      EditorGUI.BeginChangeCheck();

      _socialProvidersFoldout = EditorGUILayout.BeginFoldoutHeaderGroup(_socialProvidersFoldout, "Registered Social Providers");
      if (_socialProvidersFoldout)
      {
        var socialProviders = target.GetComponents<SocialProvider>().ToList();
        if (socialProviders.Count > 0)
          EditorGUILayout.HelpBox(string.Join("\n", socialProviders
            .Select(p => $"• {p.GetType().ToDisplayString(TypeDisplayOptions.DontShowNamespace)} [Priority {p.priority}, {ObjectNames.NicifyVariableName(p.executionMode.ToString())}]")), MessageType.None);
        else
          EditorGUILayout.HelpBox("None", MessageType.None);

        EditorGUILayout.Space();
      }
      EditorGUILayout.EndFoldoutHeaderGroup();

      _componentsFoldout = EditorGUILayout.BeginFoldoutHeaderGroup(_componentsFoldout, "Components");
      if (_componentsFoldout)
      {
        var addSocialProviderPosition = EditorGUILayout.GetControlRect(true);
        addSocialProviderPosition = EditorGUI.PrefixLabel(addSocialProviderPosition, new GUIContent("Add Social Provider"));
        EditorGUIExtensions.GenericMenuDropdown(addSocialProviderPosition, new GUIContent("(select)"), _socialProvidersTypesMenu);
      }
      EditorGUILayout.EndFoldoutHeaderGroup();

      if (EditorGUI.EndChangeCheck())
        serializedObject.ApplyModifiedProperties();
    }
  }
}