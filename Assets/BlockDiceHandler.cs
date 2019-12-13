using Fumbbl;
using Fumbbl.View;
using UnityEngine;
using UnityEngine.UI;
using static Fumbbl.Model.Types.BlockDie;

public class BlockDiceHandler : MonoBehaviour
{
    private ViewObjectList<BlockDie> BlockDice;
    private static Vector2 FullSize = new Vector2(40, 40);
    private static Vector2 SmallSize = new Vector2(30, 30);
    private static Vector2 SpacerSize = new Vector2(12, 30);

    public GameObject BlockDiePrefab;
    public Sprite SkullSprite;
    public Sprite BothDownSprite;
    public Sprite PushSprite;
    public Sprite PushPowSprite;
    public Sprite PowSprite;
    public Transform ContentObject;

    #region MonoBehaviour Methods

    // Start is called before the first frame update
    private void Start()
    {
        BlockDice = new ViewObjectList<BlockDie>(
            die =>
            {
                GameObject obj = Instantiate(BlockDiePrefab);
                var image = obj.GetComponent<Image>();
                image.sprite = GetSpriteForRoll(die.Roll);
                obj.transform.SetParent(ContentObject);
                obj.transform.localScale = Vector3.one;
                obj.name = die.Roll.Type.ToString();
                die.GameObject = obj;
            },
            die =>
            {
                Destroy(die.GameObject);
            }
        );
    }

    // Update is called once per frame
    private void Update()
    {
        var dice = FFB.Instance.Model.BlockDice;
        BlockDice.Refresh(dice, RefreshBlockDie);
    }

    private readonly System.Action<BlockDie> RefreshBlockDie = die =>
    {
        var image = die.GameObject.GetComponentInChildren<Image>();
        var color = image.color;
        if (die.Roll.Type != DieType.None)
        {
            color.a = die.Active ? 1f : 0.5f;
        }
        else
        {
            color.a = 0f;
        }
        image.color = color;
        die.GameObject.transform.localScale = Vector3.one;
        var trn = die.GameObject.GetComponent<RectTransform>();
        if (die.Roll.Type != DieType.None)
        {
            trn.sizeDelta = die.Active ? FullSize : SmallSize;
        }
        else
        {
            trn.sizeDelta = SpacerSize;
        }
    };

    #endregion

    private Sprite GetSpriteForRoll(Fumbbl.Model.Types.BlockDie roll)
    {
        switch (roll.Type)
        {
            case DieType.None: return null;
            case DieType.Skull: return SkullSprite;
            case DieType.BothDown: return BothDownSprite;
            case DieType.PowPush: return PushPowSprite;
            case DieType.Pow: return PowSprite;
            default: return PushSprite;
        }
    }
}
