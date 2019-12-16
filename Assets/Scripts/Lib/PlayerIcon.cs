using Fumbbl.Model.Types;
using System;
using UnityEngine;

namespace Fumbbl.Lib
{
    public static class PlayerIcon
    {
        public const int NormalizedIconSize = 60;

        public static GameObject GeneratePlayerIcon(Player p, GameObject iconPrefab, GameObject fallbackPrefab)
        {
            GameObject obj = PlayerIcon.CreatePlayerIcon(p, iconPrefab);
            try
            {
                var target = obj.transform.GetChild(0).gameObject;
                PlayerIcon.LoadSprite(p.Position.IconURL, target);
                return obj;
            }
            catch(Exception ex)
            {
                GameObject.Destroy(obj);
                Debug.LogError("Exception loading player sprite, falling back to abstract icons: " + ex);
                return GeneratePlayerIconAbstract(p, fallbackPrefab);
            }
        }

        public static GameObject GeneratePlayerIconAbstract(Player p, GameObject prefab)
        {
            GameObject obj = PlayerIcon.CreatePlayerIcon(p, prefab);

            // Set Background color
            var child = obj.transform.GetChild(0).gameObject;
            SpriteRenderer renderer = child.GetComponent<SpriteRenderer>();
            string c0 = p.IsHome ? FFB.Instance.Settings.Color.HomeColor : FFB.Instance.Settings.Color.AwayColor;
            Color c1;
            bool parseable = ColorUtility.TryParseHtmlString(c0, out c1);
            if (parseable){ renderer.color = c1; };

            // Set text
            TMPro.TextMeshPro text = obj.GetComponentInChildren<TMPro.TextMeshPro>();
            text.text = p.Position?.AbstractLabel ?? "*";
            return obj;
        }

        public static void LoadSprite(string iconURL, GameObject target)
        {
            Sprite resized = LoadIconSpriteSheet(iconURL);
            FFB.Instance.ExecuteOnMainThread(() =>
            {
                var renderer = target.GetComponent<SpriteRenderer>();
                RectTransform rect = target.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(192, 192);
                renderer.sprite = resized;
            });
        }

        private static void CopyTexture(Sprite s, int srcIconSize, Texture2D dest, int destMip, int y, int x)
        {
            var srcPixels = s.texture.GetPixels32(0);
            var destPixels = dest.GetPixels32();

            int srcOriginX = x * srcIconSize;
            int srcOriginY = y * srcIconSize;
            int srcWidth = 4 * srcIconSize;

            int dstOriginX = x * NormalizedIconSize + (NormalizedIconSize - srcIconSize) / 2;
            int dstOriginY = y * NormalizedIconSize + (NormalizedIconSize - srcIconSize) / 2;
            int dstWidth = 4 * NormalizedIconSize;

            for (int yy=0; yy<srcIconSize; yy++)
            {
                for (int xx=0; xx<srcIconSize; xx++)
                {
                    var srcX = srcOriginX + xx;
                    var srcY = srcOriginY + yy;

                    var dstX = dstOriginX + xx;
                    var dstY = dstOriginY + yy;

                    var pixel = srcPixels[srcX + srcWidth * srcY];
                    destPixels[dstX + dstWidth * dstY] = pixel;
                }
            }
            dest.SetPixels32(destPixels);
            dest.Apply(false);
        }

        private static GameObject CreatePlayerIcon(Player p, GameObject prefab)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            var handler = obj.GetComponent<PlayerHandler>();
            handler.Player = p;
            obj.name = p.Id;
            return obj;
        }

        private static Sprite LoadIconSpriteSheet(string iconURL)
        {
            Sprite s = FFB.Instance.SpriteCache.Get(iconURL);
            var iconSize = s.texture.width / 4;
            int numTextures = s.texture.height / iconSize;

            Sprite resized = ResizeSprite(s);
            resized.name = s.name;

            return resized;
        }

        private static Sprite ResizeSprite(Sprite s)
        {
            s.texture.filterMode = FilterMode.Point;
            var srcIconSize = s.texture.width / 4;
            var numIcons = s.texture.height / srcIconSize;

            Texture2D dest = new Texture2D(4 * NormalizedIconSize, NormalizedIconSize * numIcons, s.texture.format, false);

            Color transparent = new Color(0f, 0f, 0f, 0f);

            Color[] data = dest.GetPixels(0);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Color.clear;
            }
            dest.SetPixels(data);

            dest.Apply(false);

            var destMip = 0;
            for (int y = 0; y < numIcons; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    CopyTexture(s, srcIconSize, dest, destMip, y, x);
                }
            }

            // TODO: This should be a "Icon Scaling Mode" setting
            dest.filterMode = FilterMode.Point;
            return Sprite.Create(dest, new Rect(0, 0, dest.width, dest.height), new Vector2(0.5f, 0.5f), 1f, 0, SpriteMeshType.FullRect);
        }
    }
}
