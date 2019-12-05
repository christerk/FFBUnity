using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Fumbbl.Lib
{
    public static class PlayerIcon
    {
        private static Color HomeColour = new Color(0.66f, 0.19f, 0.19f, 1f);
        private static Color AwayColour = new Color(0f, 0f, 0.99f, 1f);

        public static GameObject GeneratePlayerIcon(Player p, GameObject prefab)
        {
            GameObject obj = PlayerIcon.CreatePlayerIcon(p, prefab);

            // Load the sprite
            var target = obj.transform.GetChild(0).gameObject;
            PlayerIcon.LoadSprite(p.Position.IconURL, target);

            return obj;
        }

        public static GameObject GenerateAbstractIcon(Player p, GameObject prefab)
        {
            GameObject obj = PlayerIcon.CreatePlayerIcon(p, prefab);

            // Set Background colour
            var child = obj.transform.GetChild(0).gameObject;
            Renderer s = child.GetComponent<Renderer>();
            s.material.color = p.IsHome ? HomeColour : AwayColour;

            // Set text
            TMPro.TextMeshProUGUI text = obj.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            text.text = p.Position?.AbstractLabel ?? "*";
            return obj;
        }

        public static GameObject CreatePlayerIcon(Player p, GameObject prefab)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            var handler = obj.GetComponent<PlayerHandler>();
            handler.Player = p;
            obj.name = p.Id;
            return obj;
        }

        public static async void LoadSprite(string iconURL, GameObject target)
        {
            Sprite resized = await LoadIconSpriteSheet(iconURL);
            FFB.Instance.ExecuteOnMainThread(() =>
            {
                var renderer = target.GetComponent<SpriteRenderer>();
                RectTransform rect = target.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(192, 192);
                renderer.sprite = resized;
            });
        }

        public static async Task<Sprite> LoadIconSpriteSheet(string iconURL)
        {
            Sprite s = await FFB.Instance.SpriteCache.GetAsync(iconURL);
            var iconSize = s.texture.width / 4;
            int numTextures = s.texture.height / iconSize;

            Sprite resized = ResizeSprite(s);
            resized.name = s.name;

            return resized;
        }

        public static Sprite ResizeSprite(Sprite s)
        {
            s.texture.filterMode = FilterMode.Point;
            var srcIconSize = s.texture.width / 4;
            var numIcons = s.texture.height / srcIconSize;

            var srcMipLevels = s.texture.mipmapCount;

            Texture2D dest = new Texture2D(160, 40 * numIcons, s.texture.format, srcMipLevels, true);

            Color transparent = new Color(0f, 0f, 0f, 0f);

            for (int mip = 0; mip < srcMipLevels; mip++)
            {
                Color[] data = dest.GetPixels(mip);
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = Color.clear;
                }
                dest.SetPixels(data, mip);
            }
            dest.Apply();

            var destMip = 0;
            for (int y = 0; y < numIcons; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    CopyTexture(s, srcIconSize, dest, destMip, y, x);
                }
            }

            // TODO: This should be a "Icon Scaling Mode" setting
            //dest.filterMode = FilterMode.Point;
            return Sprite.Create(dest, new Rect(0, 0, dest.width, dest.height), new Vector2(0.5f, 0.5f), 1f, 0, SpriteMeshType.FullRect);
        }

        private static void CopyTexture(Sprite s, int srcIconSize, Texture2D dest, int destMip, int y, int x)
        {
            if (SystemInfo.copyTextureSupport != UnityEngine.Rendering.CopyTextureSupport.None)
            {
                Graphics.CopyTexture(
                    s.texture, 0, destMip, x * srcIconSize, y * srcIconSize, srcIconSize, srcIconSize,
                    dest, 0, destMip, x * 40 + (40 - srcIconSize) / 2, y * 40 + (40 - srcIconSize) / 2
                );
            }
            else
            {
                var srcPixels = s.texture.GetPixels32();
                var destPixels = dest.GetPixels32();

                int srcOriginX = x * srcIconSize;
                int srcOriginY = y * srcIconSize;
                int srcWidth = 4 * srcIconSize;

                int dstOriginX = x * 40 + (40 - srcIconSize) / 2;
                int dstOriginY = y * 40 + (40 - srcIconSize) / 2;
                int dstWidth = 4 * 40;

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
                dest.Apply();
            }
        }
    }
}
