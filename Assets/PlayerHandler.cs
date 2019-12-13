using Fumbbl;
using Fumbbl.Lib;
using Fumbbl.Model.Types;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private GameObject Background;
    private GameObject Outline;
    private GameObject Prone;
    private GameObject Stunned;
    private Renderer BackgroundRenderer;
    private SpriteMask Mask;
    public Player Player;
    public bool HasIcon;



    ///////////////////////////////////////////////////////////////////////////
    //  MONOBEHAVIOUR METHODS  ////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////

    void Start()
    {
        Background = this.transform.GetChild(0).gameObject;
        Outline = this.transform.GetChild(1).gameObject;
        Prone = this.transform.GetChild(2).gameObject;
        Stunned = this.transform.GetChild(3).gameObject;

        BackgroundRenderer = Background.GetComponent<Renderer>();
        Mask = GetComponent<SpriteMask>();
    }

    void Update()
    {
        bool active = string.Equals(FFB.Instance.Model.ActingPlayer.PlayerId, Player.Id);
        Outline.SetActive(active);

        if (HasIcon && Mask != null && Background != null)
        {
            // Set up sprite mask and render sort order. Top/right of the field is the topmost sprite
            int order = (Player.Coordinate.Y) * 100 + Player.Coordinate.X;
            Mask.frontSortingOrder = order;
            Mask.backSortingOrder = order - 1;
            Mask.isCustomRangeActive = true;
            BackgroundRenderer.sortingOrder = order;

            // Move background image to show the correct sprite from the sheet
            var tex = Background.GetComponent<SpriteRenderer>().sprite.texture;
            int numTextures = 4 * tex.height / tex.width;
            float scale = 144f * (float)PlayerIcon.NormalizedIconSize / 30f;
            float x = (Player.IsHome ? scale * 1.5f : scale * -0.5f) - (active ? scale : 0f);
            float y = scale * (((float)numTextures) / 2f - 0.5f);
            Background.transform.localPosition = new Vector3(x, y, 0);

        }

        var state = Player.PlayerState;

        bool fade = false;
        if (state != null && !active)
        {
            fade = state.IsBeingDragged || (state.IsStanding && !state.IsActive) || (state.IsProne && !state.IsActive);
        }

        Color color = BackgroundRenderer.material.color;
        color.a = fade ? 0.7f : 1f;
        BackgroundRenderer.material.color = color;

        Prone.SetActive(state.IsProne);
        Stunned.SetActive(state.IsStunned);
    }
}
