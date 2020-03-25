using System;


namespace LinearAlgebraLibrary
{
    class Matrix : LAToolkit
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public double[,] Values { get; set; }
        private static Random randomVal { get; set; }

        public Matrix(int rows, int columns)
        {
            randomVal = new Random();
            this.Rows = rows;
            this.Columns = columns;
            Values = new double[this.Rows, this.Columns];
            Randomize();
        }

        public override void Add(int valToAdd)
        {
            for (int rowNum = 0; rowNum < Rows; rowNum++)
            {
                for (int columnNum = 0; columnNum < Columns; columnNum++)
                {
                    Values[rowNum, columnNum] += valToAdd;
                }
            }
        }

        public override void Multiply(int scalar)
        {
            for (int rowNum = 0; rowNum < Rows; rowNum++)
            {
                for (int columnNum = 0; columnNum < Columns; columnNum++)
                {
                    Values[rowNum, columnNum] *= scalar;
                }
            }
        }
        public override Matrix Multiply(Matrix otherMatrix)
        {
            try
            {
                if (this.Columns != otherMatrix.Rows)
                    throw new Exception("The columns must equal the rows to multiply");
                else
                {
                    int newColumns = this.Columns;
                    int newRows = this.Rows;
                    var newMatrix = new Matrix(newRows, newColumns);
                    for (int i = 0; i < newMatrix.Rows; i++)
                    {
                        for (int j = 0; j < newMatrix.Columns; j++)
                        {
                            for (int k = 0; k < newMatrix.Columns; k++)
                            {
                                newMatrix.Values[i, j] += this.Values[i, k] * otherMatrix.Values[k, j];
                            }
                        }
                    }
                    return newMatrix;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }

        }

        public override void Negate()
        {
            this.Multiply(-1);
        }

        public override void Subtract(int valToSub)
        {
            for (int rowNum = 0; rowNum < Rows; rowNum++)
            {
                for (int columnNum = 0; columnNum < Columns; columnNum++)
                {
                    Values[rowNum, columnNum] += valToSub;
                }
            }
        }

        public override Matrix Transpose()
        {
            int transposedRows = this.Columns;
            int transposedColumns = this.Rows;
            var transposeMatrix = new Matrix(transposedRows, transposedColumns);
            for (int columns = 0; columns < this.Columns; columns++)
            {
                for (int rows = 0; rows < this.Rows; rows++)
                {
                    transposeMatrix.Values[columns, rows] = this.Values[rows, columns];
                }
            }
            return transposeMatrix;
        }
        public override void Randomize()
        {
            for (int rows = 0; rows < this.Rows; rows++)
            {
                for (int columns = 0; columns < this.Columns; columns++)
                {
                    Values[rows, columns] = NextDouble(-1, 1);
                }
            }
        }

        private double NextDouble(double minimumDouble, double maximumDouble) =>
            randomVal.NextDouble() * (maximumDouble - minimumDouble) + minimumDouble;

    }
}
