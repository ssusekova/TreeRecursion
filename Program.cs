using System.Text.RegularExpressions;

public class Node
{
    public string Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
}

public class Program
{
    public static void Main()
    {
        #region
        Node tree = new Node
        {
            Left = new Node
            {
                Left = new Node { Value = "Первое предложение из произвольной строки" },
                Right = new Node
                {
                    Left = new Node { Value = "Другое произвольное предложение" },
                    Right = new Node { Value = "Еще одно следующее предложение, но не очень длинное" }
                }
            },
            Right = new Node
            {
                Left = new Node
                {
                    Left = new Node
                    {
                        Left = new Node { Value = "Еще одно не очень длинное предложение" },
                        Right = new Node { Value = "" }
                    },
                    Right = new Node
                    {
                        Left = new Node { Value = "" },
                        Right = new Node { Value = "Еще одно не очень длинное предложение" }
                    }
                },
                Right = new Node
                {
                    Left = new Node
                    {
                        Left = new Node { Value = "Предложение" },
                        Right = new Node { Value = "Еще одно следующее предложение, но не очень длинное" }
                    },
                    Right = new Node
                    {
                        Left = new Node { Value = "Другое произвольное предложение" },
                        Right = new Node
                        {
                            Left = new Node { Value = "Два слова" },
                            Right = new Node { Value = "Еще одно следующее предложение, но не очень длинное" }
                        }
                    }
                }
            }
        };
        #endregion

        SearchingTree(tree, null);
    }

    public static string GetLongiestWords(string value)
    {
        string? output;
        if (value == "")
            return "<Строка листа пустая>";
        try
        {
            MatchCollection matches = Regex.Matches(value, @"\b\w+\b");

            output = string.Join(" ", matches.Cast<Match>().OrderByDescending(m => m.Value.Length).Take(3)
                .Select(m => m.Value));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return output;
    }

    public static void SearchingTree(Node node, string? path)
    {
        if (node == null)
            return;

        if(node.Value != null)
        {
            string? longiestsWords = GetLongiestWords(node.Value);
            Console.Write(String.Concat(path, ": "));
            Console.WriteLine(longiestsWords);
        }
            
        SearchingTree(node.Left, String.Concat(path,"/Left"));

        SearchingTree(node.Right, String.Concat(path, "/Right"));
    }

}