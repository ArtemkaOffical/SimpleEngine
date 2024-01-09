
namespace _2D
{
    public struct Matrix
    {
        public float M00 { get; }
        public float M01 { get; }
        public float M02 { get; }
        public float M03 { get; }

        public float M10 { get; }
        public float M11 { get; }
        public float M12 { get; }
        public float M13 { get; }

        public float M20 { get; }
        public float M21 { get; }
        public float M22 { get; }
        public float M23 { get; }

        public float M30 { get; }
        public float M31 { get; }
        public float M32 { get; }
        public float M33 { get; }

        public Matrix(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33)
        {
            M00 = m00;
            M01 = m01;
            M02 = m02;
            M03 = m03;
            M10 = m10;
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M20 = m20;
            M21 = m21;
            M22 = m22;
            M23 = m23;
            M30 = m30;
            M31 = m31;
            M32 = m32;
            M33 = m33;
        }

        public Matrix(Vector4 row1, Vector4 row2, Vector4 row3, Vector4 row4) 
        {
            this.M00 = row1.x;
            this.M01 = row1.y;
            this.M02 = row1.z;
            this.M03 = row1.v;

            this.M10 = row2.x;
            this.M11 = row2.y;
            this.M12 = row2.z;
            this.M13 = row2.v;

            this.M20 = row3.x;
            this.M21 = row3.y;
            this.M22 = row3.z;
            this.M23 = row3.v;

            this.M30 = row4.x;
            this.M31 = row4.y;
            this.M32 = row4.z;
            this.M33 = row4.v;
        }

        public Matrix(Vector4[] vectors) : this(vectors[0], vectors[1], vectors[2], vectors[3])
        {
            if (vectors.Length != 4) throw new ArgumentException();
        }

        public static Matrix operator *(Matrix matrix, float num)
        {
            var m00 = matrix.M00 * num;
            var m01 = matrix.M01 * num;
            var m02 = matrix.M02 * num;
            var m03 = matrix.M03 * num;

            var m10 = matrix.M10 * num;
            var m11 = matrix.M11 * num;
            var m12 = matrix.M12 * num;
            var m13 = matrix.M13 * num;

            var m20 = matrix.M20 * num;
            var m21 = matrix.M21 * num;
            var m22 = matrix.M22 * num;
            var m23 = matrix.M23 * num;

            var m30 = matrix.M30 * num;
            var m31 = matrix.M31 * num;
            var m32 = matrix.M32 * num;
            var m33 = matrix.M33 * num;

            return new Matrix(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33);
        }

        public static Matrix operator /(Matrix matrix, float num)
        {
            var m00 = matrix.M00 / num;
            var m01 = matrix.M01 / num;
            var m02 = matrix.M02 / num;
            var m03 = matrix.M03 / num;

            var m10 = matrix.M10 / num;
            var m11 = matrix.M11 / num;
            var m12 = matrix.M12 / num;
            var m13 = matrix.M13 / num;

            var m20 = matrix.M20 / num;
            var m21 = matrix.M21 / num;
            var m22 = matrix.M22 / num;
            var m23 = matrix.M23 / num;

            var m30 = matrix.M30 / num;
            var m31 = matrix.M31 / num;
            var m32 = matrix.M32 / num;
            var m33 = matrix.M33 / num;

            return new Matrix(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33);
        }

        public static Vector3 Multiply(Matrix matrix, Vector3 vector)
        {
            var x = matrix.M00 * vector.x + matrix.M01 * vector.y + matrix.M02 * vector.z;
            var y = matrix.M10 * vector.x + matrix.M11 * vector.y + matrix.M12 * vector.z;
            var z = matrix.M20 * vector.x + matrix.M21 * vector.y + matrix.M22 * vector.z;

            return new Vector3(x, y, z);
        }

        public static Matrix Multiply(Matrix matrix, Matrix Matrix2)
        {
            var m00 = matrix.M00 * Matrix2.M00 + matrix.M01 * Matrix2.M10 + matrix.M02 * Matrix2.M20 + matrix.M03 * Matrix2.M30;
            var m01 = matrix.M00 * Matrix2.M01 + matrix.M01 * Matrix2.M11 + matrix.M02 * Matrix2.M21 + matrix.M03 * Matrix2.M31;
            var m02 = matrix.M00 * Matrix2.M02 + matrix.M01 * Matrix2.M12 + matrix.M02 * Matrix2.M22 + matrix.M03 * Matrix2.M32;
            var m03 = matrix.M00 * Matrix2.M03 + matrix.M01 * Matrix2.M13 + matrix.M02 * Matrix2.M23 + matrix.M03 * Matrix2.M33;

            var m10 = matrix.M10 * Matrix2.M00 + matrix.M11 * Matrix2.M10 + matrix.M12 * Matrix2.M20 + matrix.M13 * Matrix2.M30;
            var m11 = matrix.M10 * Matrix2.M01 + matrix.M11 * Matrix2.M11 + matrix.M12 * Matrix2.M21 + matrix.M13 * Matrix2.M31;
            var m12 = matrix.M10 * Matrix2.M02 + matrix.M11 * Matrix2.M12 + matrix.M12 * Matrix2.M22 + matrix.M13 * Matrix2.M32;
            var m13 = matrix.M10 * Matrix2.M03 + matrix.M11 * Matrix2.M13 + matrix.M12 * Matrix2.M23 + matrix.M13 * Matrix2.M33;

            var m20 = matrix.M20 * Matrix2.M00 + matrix.M21 * Matrix2.M10 + matrix.M22 * Matrix2.M20 + matrix.M23 * Matrix2.M30;
            var m21 = matrix.M20 * Matrix2.M01 + matrix.M21 * Matrix2.M11 + matrix.M22 * Matrix2.M21 + matrix.M23 * Matrix2.M31;
            var m22 = matrix.M20 * Matrix2.M02 + matrix.M21 * Matrix2.M12 + matrix.M22 * Matrix2.M22 + matrix.M23 * Matrix2.M32;
            var m23 = matrix.M20 * Matrix2.M03 + matrix.M21 * Matrix2.M13 + matrix.M22 * Matrix2.M23 + matrix.M23 * Matrix2.M33;

            var m30 = matrix.M30 * Matrix2.M00 + matrix.M31 * Matrix2.M10 + matrix.M32 * Matrix2.M20 + matrix.M33 * Matrix2.M30;
            var m31 = matrix.M30 * Matrix2.M01 + matrix.M31 * Matrix2.M11 + matrix.M32 * Matrix2.M21 + matrix.M33 * Matrix2.M31;
            var m32 = matrix.M30 * Matrix2.M02 + matrix.M31 * Matrix2.M12 + matrix.M32 * Matrix2.M22 + matrix.M33 * Matrix2.M32;
            var m33 = matrix.M30 * Matrix2.M03 + matrix.M31 * Matrix2.M13 + matrix.M32 * Matrix2.M23 + matrix.M33 * Matrix2.M33;

            return new Matrix(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33);
        }

        public static Matrix ScaleMatrix
        {
            get
            {
                return new Matrix(
                    1, 0, 0, 0,
                    0, 1, 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1);
            }
        }

        public static Matrix RotationMatrixX(int angle)
        {
            var rad = (float)Math.PI / 180 * angle;
            return new Matrix(
                1, 0, 0, 0,
                0, (float)Math.Cos(rad), (float)-Math.Sin(rad), 0,
                0, (float)Math.Sin(rad), (float)Math.Cos(rad), 0,
                0, 0, 0, 1);
        }
    
        public static Matrix RotationMatrixY(int angle)
        {
            var rad = (float)Math.PI / 180 * angle;

            return new Matrix(
                (float)Math.Cos(rad), 0, (float)Math.Sin(rad), 0,
                0, 1, 0, 0,
                -(float)Math.Sin(rad), 0, (float)Math.Cos(rad), 0,
                0, 0, 0, 1);
        }

        public static Matrix RotationMatrixZ(int angle)
        {
            var rad = (float)Math.PI / 180 * angle;

            return new Matrix(
               (float)Math.Cos(rad), -(float)Math.Sin(rad), 0, 0,
               (float)Math.Sin(rad), (float)Math.Cos(rad), 0, 0,
               0, 0, 1, 0,
               0, 0, 0, 1);
        }
    }
}
