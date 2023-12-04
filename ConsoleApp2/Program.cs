using System;
using System.Collections.Generic;

abstract class GraphicPrimitive
{
    public int X { get; set; }
    public int Y { get; set; }

    public abstract void Draw();
    public abstract void Move(int x, int y);
    public abstract void Scale(float factor);
}

class Circle : GraphicPrimitive
{
    public int Radius { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Circle at ({X}, {Y}) with Radius {Radius}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        Radius = (int)(Radius * factor);
    }
}

class Rectangle : GraphicPrimitive
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Rectangle at ({X}, {Y}) with Width {Width} and Height {Height}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        Width = (int)(Width * factor);
        Height = (int)(Height * factor);
    }
}

class Triangle : GraphicPrimitive
{
    public override void Draw()
    {
        Console.WriteLine($"Drawing Triangle at ({X}, {Y})");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
    }
}

class Group : GraphicPrimitive
{
    private List<GraphicPrimitive> members = new List<GraphicPrimitive>();

    public void AddMember(GraphicPrimitive member)
    {
        members.Add(member);
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Group at ({X}, {Y})");
        foreach (var member in members)
        {
            member.Draw();
        }
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
        foreach (var member in members)
        {
            member.Move(x, y);
        }
    }
    public override void Scale(float factor)
    {
        foreach (var member in members)
        {
            member.Scale(factor);
        }
    }
}
class GraphicsEditor
{
    private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public void DrawAll()
    {
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }
}
class Program
{
    static void Main()
    {
        GraphicsEditor editor = new GraphicsEditor();

        Circle circle = new Circle { X = 10, Y = 20, Radius = 5 };
        Rectangle rectangle = new Rectangle { X = 30, Y = 40, Width = 10, Height = 15 };
        Triangle triangle = new Triangle { X = 50, Y = 60 };

        Group group = new Group { X = 70, Y = 80 };
        group.AddMember(circle);
        group.AddMember(rectangle);

        editor.AddPrimitive(circle);
        editor.AddPrimitive(rectangle);
        editor.AddPrimitive(triangle);
        editor.AddPrimitive(group);
    editor.DrawAll();
        editor.DrawAll();
        foreach (var primitive in editor.Primitives)
        {
            primitive.Scale(2.0f);
        }

        editor.DrawAll();
    }
}
