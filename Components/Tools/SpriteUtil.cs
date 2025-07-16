using System;
using MelonLoader;
using onnxware.Globals;
using UnityEngine;
using UnityEngine.UI;

namespace onnxware.Components.Tools
{
    internal class SpriteUtil
    {
        public static Texture2D CreateTextureFromBase64(string base64)
        {
            byte[] array = Convert.FromBase64String(base64);
            Texture2D texture2D = new Texture2D(2, 2);
            ImageConversion.LoadImage(texture2D, array);
            return texture2D;
        }

        // Token: 0x060002C7 RID: 711 RVA: 0x000172C8 File Offset: 0x000154C8
        public static Sprite Create(Texture2D texture, Rect rect, Vector2 size)
        {
            return Sprite.Create(texture, rect, size);
        }

        // Token: 0x060002C8 RID: 712 RVA: 0x000172E4 File Offset: 0x000154E4
        public static void ApplySpriteToButton(string objectName, string image)
        {
            try
            {
                bool flag = FileHelper.IsPath(image);
                Sprite overrideSprite;
                if (flag)
                {
                    overrideSprite = SpriteUtil.LoadFromDisk(image, 100f);
                }
                else
                {
                    image = Path.Combine(Environment.CurrentDirectory, Variables.dataPath, image);
                    overrideSprite = SpriteUtil.LoadFromDisk(image, 100f);
                }
                Variables.userInterface.transform.Find(objectName).transform.Find("Background").GetComponent<Image>().overrideSprite = overrideSprite;
                //OdiumConsole.LogGradient("Odium", "Sprite applied to " + objectName + " successfully!", LogLevel.Info, false);
            }
            catch (Exception ex)
            {
                //OdiumConsole.LogException(ex, null);
            }
        }

        public static void ApplySpriteToMenu(string objectName, string image)
        {
            try
            {
                bool flag = FileHelper.IsPath(image);
                Sprite overrideSprite;
                if (flag)
                {
                    overrideSprite = SpriteUtil.LoadFromDisk(image, 100f);
                }
                else
                {
                    image = Path.Combine(Environment.CurrentDirectory, Variables.dataPath, image);
                    overrideSprite = SpriteUtil.LoadFromDisk(image, 100f);
                }
                Variables.userInterface.transform.Find(objectName).GetComponent<Image>().overrideSprite = overrideSprite;
                //OdiumConsole.LogGradient("Odium", "Sprite applied to " + objectName + " successfully!", LogLevel.Info, false);
            }
            catch (Exception ex)
            {
                //OdiumConsole.LogException(ex, null);
            }
        }

        // Token: 0x060002CA RID: 714 RVA: 0x0001743C File Offset: 0x0001563C
        public static void ApplyColorToMenu(string objectName, Color color)
        {
            try
            {
                Variables.userInterface.transform.Find(objectName).GetComponent<Image>().m_Color = color;
                //OdiumConsole.LogGradient("Odium", "Color applied to " + objectName + " successfully!", LogLevel.Info, false);
            }
            catch (Exception ex)
            {
                //OdiumConsole.LogException(ex, null);
            }
        }

        public static void ApplyColorToButton(string objectName, Color color)
        {
            try
            {
                Variables.userInterface.transform.Find(objectName).GetComponent<Image>().m_Color = color;
                //OdiumConsole.LogGradient("Odium", "Color applied to " + objectName + " successfully!", LogLevel.Info, false);
            }
            catch (Exception ex)
            {
                //OdiumConsole.LogException(ex, null);
            }
        }

        // Token: 0x060002CC RID: 716 RVA: 0x0001750C File Offset: 0x0001570C
        public static Sprite LoadFromDisk(string path, float pixelsPerUnit = 100f)
        {
            if (!FileHelper.IsPath(path))
            {
                MelonLogger.Warning("Cannot load sprite: Path is null or empty");
                return null;
            }

            byte[] array = File.ReadAllBytes(path);

            if (array == null || array.Length == 0)
            {
                MelonLogger.Warning("Cannot load sprite: No data found at path '" + path + "'");
                return null;
            }

            Texture2D texture2D = new Texture2D(2, 2);

            if (!ImageConversion.LoadImage(texture2D, array))
            {
                MelonLogger.Error("Failed to convert image data to texture from path '" + path + "'");
                return null;
            }

            Rect rect = new(0f, 0f, (float)texture2D.width, (float)texture2D.height);

            return Sprite.Create(texture2D, rect, new Vector2(0.5f, 0.5f), pixelsPerUnit, 0U, 0, Vector4.zero, false);
        }

        public static Sprite LoadSpriteViaVRCPath(string imgName, float pixelsPerUnit = 100f) => LoadFromDisk(Path.Combine(Environment.CurrentDirectory, Variables.dataPath, imgName), pixelsPerUnit);
    }
}
