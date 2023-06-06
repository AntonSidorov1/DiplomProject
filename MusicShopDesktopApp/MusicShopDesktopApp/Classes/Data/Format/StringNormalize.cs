using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MusicShopDesktopApp
{
    public static class StringNormalize
    {

        public static string FormatToEnd(string text)
        {
            string result = "";

            string[] parts = text.Split('.', ',');
            List<int> pos = new List<int>();
            int pos1 = 0;

            for (int i = 0; i < parts.Length; i++)
            {
                string[] parts1 = parts[i].Split('_');
                pos1 += parts1.Length;
                pos.Add(pos1);
            }
            string positions = string.Join(",", pos.ToArray());
            result = string.Join("_", parts);
            result = string.Join("_", result, positions);

            return result;
        }


        public static string FormatFromEnd(string text)
        {
            string result = "";

            string[] parts = text.Split('_');

            string positions = parts[parts.Length - 1];
            string[] pos1 = positions.Split(',', '.', '-');
            List<int> pos = new List<int>();
            for (int i = 0; i < pos1.Length; i++)
            {
                pos.Add(Convert.ToInt32(pos1[i]));
            }
            pos.Add(parts.Length - 1);
            List<string> parts1 = new List<string>(parts);
            parts1.RemoveAt(parts.Length - 1);
            int pos2 = 0, pos3 = pos[0];
            List<string> results = new List<string>();
            for (int i = 0; i < pos.Count; i++)
            {
                pos3 = pos[i];
                if (pos3 > pos2)
                {
                    List<string> line = new List<string>();
                    for (int j = pos2; j < pos3; j++)
                    {
                        line.Add(parts1[j]);
                    }
                    results.Add(string.Join("_", line));
                    pos2 = pos3;
                }
            }

            return string.Join(".", results);
        }

        public static string DropDefices(string text)
        {
            text = text.Replace('_', ' ');
            text = text.Replace('+', ' ');
            text = text.Replace('-', ' ');
            text = text.Replace('.', ' ');
            text = text.Replace(',', ' ');
            text = text.Trim();
            return string.Join("", text.Split(' '));
        }

        public static string Normalize(string text, bool snakeCase = true, bool lower = true, char newSymwol = ' ', FormatEnd formatEnd = FormatEnd.FromEnd)
        {
            if (snakeCase)
            {
                text = Regex.Replace(text, "([a-z])([A-Z])", "$1_$2");
                text = Regex.Replace(text, "([a-z])([0-9])", "$1_$2");
                text = Regex.Replace(text, "([A-Z])([0-9])", "$1_$2");
                try
                {
                    text = Regex.Replace(text, "([а-Я])([а-Я])", "$1_$2");
                    text = Regex.Replace(text, "([а-я])([0-9])", "$1_$2");
                    text = Regex.Replace(text, "([А-Я])([0-9])", "$1_$2");

                    text = Regex.Replace(text, "([a-z])([А-Я])", "$1_$2");
                    text = Regex.Replace(text, "([а-я])([A-Z])", "$1_$2");
                }
                catch
                {

                }

            }
            if (lower)
                text = text.ToLower();
            if(formatEnd == FormatEnd.ToEnd)
            {
                try
                {
                    text = FormatToEnd(text);
                }
                catch
                {

                }
            }
            else if(formatEnd == FormatEnd.FromEnd)
            {
                try
                {
                    text = FormatFromEnd(text);
                }
                catch
                {

                }
            }
            text = text.Replace('_', ' ');
            text = text.Replace('+', ' ');
            text = text.Replace('-', ' ');
            text = text.Replace('.', ' ');
            text = text.Replace(',', ' ');
            text = text.Trim();
            text = string.Join(" ", text.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries));
            text = text.Replace(' ', newSymwol);
            return text;
        }


        
    }
}

public enum FormatEnd
{
    None = 0,
    ToEnd = 1,
    FromEnd = 2
}
