using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Transformation
    {
        // Matrix used to represent the transformation
        private double[,] transformationMatrix = new double[4, 4];

        public double[,] TransformationMatrix
        {
            get { return transformationMatrix; }
        }

        public Transformation()
        {
            this.transformationMatrix = IdentityMatrix();
        }

        public Transformation(double[,] transformationMatrix)
        {
            this.transformationMatrix = transformationMatrix;
        }

        // Creates and Returns a new Identity Matrix
        public double[,] IdentityMatrix()
        {
            double[,] identityMatrix = {
                { 1.0, 0.0, 0.0, 0.0},
                { 0.0, 1.0, 0.0, 0.0},
                { 0.0, 0.0, 1.0, 0.0},
                { 0.0, 0.0, 0.0, 1.0},
            };

            return identityMatrix;
        }

        // Creates and Returns a new Transformation by applying the given Translation to the current TransformationMatrix
        public Transformation Translate(double x, double y, double z)
        {
            double[,] translateMatrix =
            {
                { 1.0, 0.0, 0.0, x},
                { 0.0, 1.0, 0.0, y},
                { 0.0, 0.0, 1.0, z},
                { 0.0, 0.0, 0.0, 1.0},
            };

            double[,]? resultMatrix = MultiplyMatrix(this.transformationMatrix, translateMatrix);

            if (resultMatrix == null)
                return this;

            return new Transformation(resultMatrix);
        }

        // Creates and Returns a new Transformation by applying the given Rotation in the X axis to the current TransformationMatrix
        public Transformation RotateX(double angle)
        {
            angle *= (Math.PI / 180.0);

            double[,] rotationMatrix =
            {
                { 1.0, 0.0, 0.0, 0.0 },
                { 0.0, Math.Cos(angle), -Math.Sin(angle), 0.0 },
                { 0.0, Math.Sin(angle), Math.Cos(angle), 0.0 },
                { 0.0, 0.0, 0.0, 1.0 }
            };

            double[,]? resultMatrix = MultiplyMatrix(this.transformationMatrix, rotationMatrix);

            if (resultMatrix == null)
                return this;

            return new Transformation(resultMatrix);
        }

        // Creates and Returns a new Transformation by applying the given Rotation in the Y axis to the current TransformationMatrix
        public Transformation RotateY(double angle)
        {
            angle *= (Math.PI / 180.0);

            double[,] rotationMatrix =
            {
                { Math.Cos(angle), 0.0, Math.Sin(angle), 0.0 },
                { 0.0, 1.0, 0.0, 0.0 },
                { -Math.Sin(angle), 0.0, Math.Cos(angle), 0.0 },
                { 0.0, 0.0, 0.0, 1.0 }
            };

            double[,]? resultMatrix = MultiplyMatrix(this.transformationMatrix, rotationMatrix);

            if (resultMatrix == null)
                return this;

            return new Transformation(resultMatrix);
        }

        // Creates and Returns a new Transformation by applying the given Rotation in the Z axis to the current TransformationMatrix
        public Transformation RotateZ(double angle)
        {
            angle *= (Math.PI / 180.0);

            double[,] rotationMatrix =
            {
                { Math.Cos(angle), -Math.Sin(angle), 0.0, 0.0 },
                { Math.Sin(angle), Math.Cos(angle), 0.0, 0.0 },
                { 0.0, 0.0, 1.0, 0.0 },
                { 0.0, 0.0, 0.0, 1.0 }
            };

            double[,]? resultMatrix = MultiplyMatrix(this.transformationMatrix, rotationMatrix);

            if (resultMatrix == null)
                return this;

            return new Transformation(resultMatrix);
        }

        // Creates and Returns a new Transformation by applying the given Scale to the current TransformationMatrix
        public Transformation Scale(double x, double y, double z)
        {
            double[,] scaleMatrix =
            {
                { x, 0.0, 0.0, 0.0 },
                { 0.0, y, 0.0, 0.0 },
                { 0.0, 0.0, z, 0.0 },
                { 0.0, 0.0, 0.0, 1.0 },
            };

            double[,]? resultMatrix = MultiplyMatrix(this.transformationMatrix, scaleMatrix);

            if (resultMatrix == null)
                return this;

            return new Transformation(resultMatrix);
        }

        public Vector4 ApplyTransformation(Vector4 vec)
        {
            float[] resultValues = new float[4];
            float[] vecValues = {vec.X, vec.Y, vec.Z, vec.W};

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    resultValues[i] += (float)transformationMatrix[i, j] * vecValues[j];

            for (int i = 0; i < 4; i++)
                if (Math.Abs(resultValues[i]) < 1.0E-5)
                    resultValues[i] = 0.0f;

            return new Vector4(resultValues[0], resultValues[1], resultValues[2], resultValues[3]);
        }

        // Creates and Returns a new Transformation by transposing the current TransformationMatrix
        public Transformation Transpose()
        {
            double[,] transposedMatrix = new double[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    transposedMatrix[j, i] = this.transformationMatrix[i, j];

            return new Transformation(transposedMatrix);
        }

        // Creates and Returns a new Transformation by Inverting the current Matrix
        public Transformation Inverse()
        {
            return new Transformation(MatrixInverse(this.transformationMatrix));
        }

        public static Transformation? operator *(Transformation t1, Transformation t2)
        {
            double[,]? result = MultiplyMatrix(t1.transformationMatrix, t2.transformationMatrix);

            if (result == null)
                return null;

            return new Transformation(result);
        }

        //
        // TODO: Maybe move all of the following code to a static class? Something like Utils or MatrixUtils?
        //

        // Multiplies the two given Matrixes and returns the result. Returns null if the Matrixes can't be multiplied
        private static double[,]? MultiplyMatrix(double[,] matrixA, double[,] matrixB)
        {
            int matrixARows = matrixA.GetLength(0);
            int matrixACols = matrixA.GetLength(1);
            int matrixBRows = matrixB.GetLength(0);
            int matrixBCols = matrixB.GetLength(1);

            if (matrixACols != matrixBRows)
                return null;
            
            double temp = 0.0;
            double[,] matrixResult = new double[matrixARows, matrixBCols];

            for (int i = 0; i < matrixARows; i++)
            {
                for (int j = 0; j < matrixBCols; j++)
                {
                    temp = 0;

                    for (int k = 0; k < matrixACols; k++)
                    {
                        temp += matrixA[i, k] * matrixB[k, j];
                    }

                    matrixResult[i, j] = temp;
                }
            }

            return matrixResult;
        }

        // Decomposes the given matrix (Code taken from: https://jamesmccaffrey.wordpress.com/2015/03/06/inverting-a-matrix-using-c/)
        private double[,] MatrixDecompose(double[,] matrix, out int[] perm, out int toggle)
        {
            // Doolittle LUP decomposition with partial pivoting.
            // rerturns: result is L (with 1s on diagonal) and U;
            // perm holds row permutations; toggle is +1 or -1 (even or odd)
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1); // assume square
            if (rows != cols)
                throw new Exception("Attempt to decompose a non-square m");

            int n = rows; // convenience

            double[,] result = MatrixDuplicate(matrix);

            perm = new int[n]; // set up row permutation result
            for (int i = 0; i < n; ++i) { perm[i] = i; }

            toggle = 1; // toggle tracks row swaps.
                        // +1 -greater-than even, -1 -greater-than odd. used by MatrixDeterminant

            for (int j = 0; j < n - 1; ++j) // each column
            {
                double colMax = Math.Abs(result[j, j]); // find largest val in col
                int pRow = j;

                // reader Matt V needed this:
                for (int i = j + 1; i < n; ++i) 
                {
                    if (Math.Abs(result[i, j]) > colMax)
                    {
                        colMax = Math.Abs(result[i, j]);
                        pRow = i;
                    }
                }
                // Not sure if this approach is needed always, or not.

                if (pRow != j) // if largest value not on pivot, swap rows
                {
                    double temp;
                    
                    for (int k = 0; k < cols; k++)
                    {
                        temp = result[pRow, k];
                        result[pRow, k] = result[j, k];
                        result[j, k] = temp;
                    }

                    int tmp = perm[pRow]; // and swap perm info
                    perm[pRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }

                if (result[j, j] == 0.0)
                {
                    // find a good row to swap
                    int goodRow = -1;
                    for (int row = j + 1; row < n; ++row)
                    {
                        if (result[row, j] != 0.0)
                            goodRow = row;
                    }

                    if (goodRow == -1)
                        throw new Exception("Cannot use Doolittle's method");

                    // swap rows so 0.0 no longer on diagonal

                    double temp;

                    for (int k = 0; k < cols; k++)
                    {
                        temp = result[goodRow, k];
                        result[goodRow, k] = result[j, k];
                        result[j, k] = temp;
                    }

                    int tmp = perm[goodRow]; // and swap perm info
                    perm[goodRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }

                for (int i = j + 1; i < n; ++i)
                {
                    result[i, j] /= result[j, j];
                    for (int k = j + 1; k < n; ++k)
                    {
                        result[i, k] -= result[i, j] * result[j, k];
                    }
                }
            } // main j column loop

            return result;
        }

        // Inverts the given Matrix (Code from: https://jamesmccaffrey.wordpress.com/2015/03/06/inverting-a-matrix-using-c/)
        private double[,] MatrixInverse(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double[,] result = MatrixDuplicate(matrix);

            int[] perm;
            int toggle;
            double[,] lum = MatrixDecompose(matrix, out perm, out toggle);
            if (lum == null)
                throw new Exception("Unable to compute inverse");

            double[] b = new double[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                        b[j] = 1.0;
                    else
                        b[j] = 0.0;
                }

                double[] x = HelperSolve(lum, b);

                for (int j = 0; j < n; ++j)
          result[j, i] = x[j];
            }
            return result;
        }

        private double[] HelperSolve(double[,] luMatrix, double[] b)
        {
            int n = luMatrix.GetLength(0);
            double[] x = new double[n];
            b.CopyTo(x, 0);

            for (int i = 1; i < n; ++i)
            {
                double sum = x[i];

                for (int j = 0; j < i; ++j)
                    sum -= luMatrix[i, j] * x[j];

                x[i] = sum;
            }

            x[n - 1] /= luMatrix[n - 1, n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                double sum = x[i];

                for (int j = i + 1; j < n; ++j)
                    sum -= luMatrix[i, j] * x[j];

                x[i] = sum / luMatrix[i, i];
            }

            return x;
        }

        private double[,] MatrixDuplicate(double[,] matrix)
        {
            double[,] result = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); ++i)
                for (int j = 0; j < matrix.GetLength(1); ++j)
                    result[i, j] = matrix[i, j];

            return result;
        }
    }
}
