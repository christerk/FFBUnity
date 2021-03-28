using Fumbbl;
using Fumbbl.Lib;
using Fumbbl.Model.Types;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour
{
    private Camera Camera;
    public Player Player;
    public bool HasIcon;

    public Material NormalMaterial;
    public Material SelectedMaterial;

    private GameObject Background;
    private GameObject Outline;
    private GameObject Prone;
    private GameObject Stunned;
    private Material Material;

    private FieldHandler FieldHandler;

    #region MonoBehaviour Methods

    private void Start()
    {
        Background = this.transform.GetChild(0).gameObject;
        Prone = this.transform.GetChild(1).gameObject;
        Stunned = this.transform.GetChild(2).gameObject;

        SelectedMaterial.SetColor("_OutlineColor", Color.yellow);
        SelectedMaterial.SetFloat("_OutlineThickness", 1f);

        var renderer = Background.GetComponent<MeshRenderer>();
        Material = renderer.material;

        Camera = Camera.main;
        foreach (var obj in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            var h = obj.GetComponent<FieldHandler>();
            if (h != null)
            {
                FieldHandler = h;
            }
        }
    }

    private void Update()
    {
        var actingPlayer = FFB.Instance.Model.ActingPlayer;
        bool active = string.Equals(actingPlayer?.PlayerId, Player.Id);

        if (HasIcon && Background != null)
        {
            var renderer = Background.GetComponent<MeshRenderer>();
            Material = renderer.material;

            // Move background image to show the correct sprite from the sheet

            var x = (float) (Player.IsHome ? 0 : 2) + (active ? 1 : 0);
            var y = (float) 0;

            Material.SetFloat("X", x);
            Material.SetFloat("Y", y);
        }

        var state = Player.PlayerState;

        bool fade = false;
        if (state != null && !active)
        {
            fade = state.IsBeingDragged || (state.IsStanding && !state.IsActive) || (state.IsProne && !state.IsActive);
        }

        Material.SetFloat("Fade", fade ? 0.5f : 1f);

        Material.SetFloat("Outline", active ? 1f : 0f);

        FieldHandler.SelectionMarker.SetActive(actingPlayer.PlayerId != null);

        if (active)
        {
            var markerPosition = FieldHandler.SelectionMarker.transform.position;
            var newPos = FieldHandler.FieldToWorldCoordinates(Player.Coordinate.X, Player.Coordinate.Y, markerPosition.y);
            FieldHandler.SelectionMarker.transform.position = newPos;
        }

        this.transform.rotation = Camera.transform.rotation;

        //Color color = BackgroundRenderer.color;
        //color.a = fade ? 0.7f : 1f;
        //BackgroundRenderer.color = color;

        Prone.SetActive(state.IsProne);
        Stunned.SetActive(state.IsStunned);
    }

    #endregion
}
