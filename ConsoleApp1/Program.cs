using System;

class Quaternion
{
    public double W { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public Quaternion(double w, double x, double y, double z)
    {
        W = w;
        X = x;
        Y = y;
        Z = z;
    }
    public static Quaternion operator +(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.W + q2.W, q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z);
    }
    public static Quaternion operator -(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.W - q2.W, q1.X - q2.X, q1.Y - q2.Y, q1.Z - q2.Z);
    }
    public static Quaternion operator *(Quaternion q1, Quaternion q2)
    {
        double w = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z;
        double x = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y;
        double y = q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X;
        double z = q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W;

        return new Quaternion(w, x, y, z);
    }
    public double Norm()
    {
        return Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
    }
    public Quaternion Conjugate()
    {
        return new Quaternion(W, -X, -Y, -Z);
    }
    public Quaternion Inverse()
    {
        double normSquared = W * W + X * X + Y * Y + Z * Z;

        if (normSquared == 0)
        {
            throw new InvalidOperationException("Cannot invert a quaternion with zero norm.");
        }

        double reciprocal = 1.0 / normSquared;

        return new Quaternion(W * reciprocal, -X * reciprocal, -Y * reciprocal, -Z * reciprocal);
    }
    public static bool operator ==(Quaternion q1, Quaternion q2)
    {
        return q1.W == q2.W && q1.X == q2.X && q1.Y == q2.Y && q1.Z == q2.Z;
    }

    public static bool operator !=(Quaternion q1, Quaternion q2)
    {
        return !(q1 == q2);
    }
    public double[,] ToRotationMatrix()
    {
        double[,] matrix = new double[3, 3];

        matrix[0, 0] = 1 - 2 * (Y * Y + Z * Z);
        matrix[0, 1] = 2 * (X * Y - W * Z);
        matrix[0, 2] = 2 * (X * Z + W * Y);

        matrix[1, 0] = 2 * (X * Y + W * Z);
        matrix[1, 1] = 1 - 2 * (X * X + Z * Z);
        matrix[1, 2] = 2 * (Y * Z - W * X);

        matrix[2, 0] = 2 * (X * Z - W * Y);
        matrix[2, 1] = 2 * (Y * Z + W * X);
        matrix[2, 2] = 1 - 2 * (X * X + Y * Y);

        return matrix;
    }
}