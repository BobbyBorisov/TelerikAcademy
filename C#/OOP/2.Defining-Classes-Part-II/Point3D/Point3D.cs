using System.Text;
public struct Point3D {

    private static readonly Point3D point0 = new Point3D(0,0,0);
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public Point3D(int aX, int aY, int aZ)
        :this()
    {
        X = aX;
        Y = aY;
        Z = aZ;
    }

    public static Point3D GetStart() {
        return point0;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("X("+this.X+") Y("+this.Y+") Z("+this.Z+")");

        return sb.ToString();
    }
}