using Fumbbl.Model.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerCardHandler : MonoBehaviour
{
    public Sprite HomeBG;
    public Sprite AwayBG;
    public bool Home;
    public TMPro.TextMeshPro Name;
    public TMPro.TextMeshPro Position;
    public TMPro.TextMeshPro MA;
    public TMPro.TextMeshPro ST;
    public TMPro.TextMeshPro AG;
    public TMPro.TextMeshPro AV;
    public TMPro.TextMeshPro SPP;
    public TMPro.TextMeshPro Level;
    public TMPro.TextMeshPro Skills;
    
    public SpriteRenderer background;

    void Start()
    {
        Color homeColor = new Color(0.4434f, 0.0376f, 0.0376f, 0.8745f);
        Color awayColor = new Color(0.0392f, 0.1588f, 0.4431f, 0.8745f);
        background.sprite = Home ? HomeBG : AwayBG;
    }

    public void SetPlayer(Player player)
    {
        if (player != null)
        {
            Name.text = player.Name;
            Position.text = player.Position?.Name;
            MA.text = player.Movement.ToString();
            ST.text = player.Strength.ToString();
            AG.text = player.Agility.ToString();
            AV.text = player.Armour.ToString();
            SPP.text = player.Spp.ToString();
            Skills.text = string.Join("\n", player.Skills);
            Level.text = player.Level;
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
