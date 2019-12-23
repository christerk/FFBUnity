using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
///   Scene component which prevents deselection of GameObjects.
/// </summary>
/// <remarks>
/// In a scene it is possible to take out focus from a Input Field or any other Gameobject by clicking on the background area with the mouse. This behaviour can not get prevented with raycasts; the selected object of the scene should be remembered and the restore the selection immediately if it was taken. This script does that.
/// </remarks>
public class PreventGameObjectDeselect : MonoBehaviour
{
    private GameObject selected;

    #region MonoBehaviour Methods

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(selected);
        }
        else
        {
            selected = EventSystem.current.currentSelectedGameObject;
        }
    }

    # endregion
}
