

namespace LinearAlgebraLibrary
{
    abstract class LAToolkit
    {

        public abstract void Add(int n);

        public abstract void Subtract(int n);

        public abstract void Negate();

        public abstract void Randomize();

        public abstract void Multiply(int n);

        public virtual Matrix Multiply(Matrix n)
        {
            return default;
        }
        public virtual Matrix Transpose()
        {
            return default;
        }
    }
}
