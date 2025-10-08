public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            if (Left is null)
            {
                Left = new Node(value);
            }
            else
            {
                Left.Insert(value);
            }
        }
        else if (value > Data)
        {
            if (Right is null)
            {
                Right = new Node(value);
            }
            else
            {
                Right.Insert(value);
            }
        }
    }


    public bool Contains(int value)
    {
        // same value
        if (value == Data)
        {
            return true;
        }
        // smaller value
        else if (value < Data)
        {
            // no left node
            if (Left is null)
            {
                return false;
            }
            // search left
            else
            {
                return Left.Contains(value);
            }
        }
        // bigger value
        else
        {
            // no right node
            if (Right is null)
            {
                return false;
            }
            // search right
            else
            {
                return Right.Contains(value);
            }
        }
    }

    public int GetHeight()
    {
        // if no left or right node height is 1
        if (Left is null && Right is null)
        {
            return 1;
        }

        // get left height
        int leftHeight = 0;
        if (Left is not null)
        {
            leftHeight = Left.GetHeight();
        }

        // get right height
        int rightHeight = 0;
        if (Right is not null)
        {
            rightHeight = Right.GetHeight();
        }

        // return 1 plus the bigger height
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}