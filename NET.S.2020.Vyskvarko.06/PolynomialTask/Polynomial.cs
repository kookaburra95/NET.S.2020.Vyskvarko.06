using System;
using System.Text;

namespace PolynomialTask
{
    public sealed class Polynomial
    {
        /// <summary>
        /// Coefficient of a polynomial.
        /// </summary>
        public double[] Coefficients { get; private set; }

        /// <summary>
        /// Constructor initializes the property coefficients.
        /// </summary>
        /// <param name="coefficients">Coefficient of a polynomial.</param>
        public Polynomial(double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException();
            }

            if (coefficients.Length == 0)
            {
                throw new ArgumentException();
            }

            Coefficients = coefficients;
        }

        /// <summary>
        /// Degrees of a polynomial.
        /// </summary>
        public int Degree => Coefficients.Length;

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <returns></returns>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= Degree)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.Coefficients[index];
            }
        }

        /// <summary>
        /// Compares two polynomial objects.
        /// </summary>
        /// <param name="obj">Boxed polynomial.</param>
        /// <returns>True if polynomials are equal, else false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Polynomial)obj);
        }

        /// <summary>
        /// Compares two polynomial objects.
        /// </summary>
        /// <param name="polynomial">Polynomial.</param>
        /// <returns>True if polynomials are equal, else false.</returns>
        public bool Equals(Polynomial polynomial)
        {
            if (ReferenceEquals(null, polynomial))
            {
                return false;
            }

            if (ReferenceEquals(this, polynomial))
            {
                return true;
            }

            if (this.Coefficients.Length != polynomial.Coefficients.Length)
            {
                return false;
            }

            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (Coefficients[i] - polynomial.Coefficients[i] >= double.Epsilon)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Provides a polynomial as a string.
        /// </summary>
        /// <returns>Polynomial as a string.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < Degree; i++)
            {
                if (i == 0)
                {
                    stringBuilder.AppendFormat($"{Coefficients[i]}");
                    continue;
                }

                if (Coefficients[i] > 0 && stringBuilder.Length > 0)
                {
                    stringBuilder.AppendFormat($" + {Coefficients[i]}*x^{i}");
                }
                else if (Coefficients[i] == 0)
                {
                    stringBuilder.AppendFormat("");
                }
                else
                {
                    stringBuilder.AppendFormat($" {Coefficients[i]}*x^{i}");
                }
            }

            return stringBuilder.ToString().Trim();
        }

        /// <summary>
        /// Returns a Hash of a polynomial based on a Hash of coefficients.
        /// </summary>
        /// <returns>Hash polynomial.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// The operation of adding two polynomials.
        /// </summary>
        /// <param name="firstPolynomial">First polynomial.</param>
        /// <param name="secondPolynomial">Second polynomial.</param>
        /// <returns>The sum of two polynomials.</returns>
        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, null) || ReferenceEquals(secondPolynomial, null))
            {
                throw new ArgumentNullException();
            }

            var size = Math.Max(firstPolynomial.Degree, secondPolynomial.Degree);

            double[] result = new double[size];

            for (int i = 0; i < firstPolynomial.Degree; i++)
            {
                result[i] = firstPolynomial[i];
            }

            for (int i = 0; i < secondPolynomial.Degree; i++)
            {
                result[i] += secondPolynomial[i];
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Subtraction operation of two polynomials.
        /// </summary>
        /// <param name="firstPolynomial">First polynomial.</param>
        /// <param name="secondPolynomial">Second polynomial.</param>
        /// <returns>The difference of two polynomials.</returns>
        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, null) || ReferenceEquals(secondPolynomial, null))
            {
                throw new ArgumentNullException();
            }

            var size = Math.Max(firstPolynomial.Degree, secondPolynomial.Degree);

            double[] result = new double[size];

            for (int i = 0; i < firstPolynomial.Degree; i++)
            {
                result[i] = firstPolynomial[i];
            }

            for (int i = 0; i < secondPolynomial.Degree; i++)
            {
                result[i] -= secondPolynomial[i];
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// The operation of multiplying two polynomials.
        /// </summary>
        /// <param name="firstPolynomial">First polynomial.</param>
        /// <param name="secondPolynomial">Second polynomial.</param>
        /// <returns>The product of two polynomials.</returns>
        public static Polynomial operator *(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, null) || ReferenceEquals(secondPolynomial, null))
            {
                throw new ArgumentNullException();
            }

            double[] firstPolyCoefficients = firstPolynomial.Coefficients;
            double[] secondPolyCoefficients = secondPolynomial.Coefficients;

            var size = firstPolynomial.Degree + secondPolynomial.Degree - 1;
            double[] result = new double[size];

            for (int i = 0; i < firstPolynomial.Degree; i++)
            {
                for (int j = 0; j < secondPolynomial.Degree; j++)
                {
                    result[i + j] += firstPolyCoefficients[i] * secondPolyCoefficients[j];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Compares two polynomials.
        /// </summary>
        /// <param name="firstPolynomial">First polynomial.</param>
        /// <param name="secondPolynomial">Second polynomial.</param>
        /// <returns>Boolean result of comparison.</returns>
        public static bool operator ==(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, null) || ReferenceEquals(secondPolynomial, null))
            {
                return false;
            }

            if (ReferenceEquals(firstPolynomial, secondPolynomial))
            {
                return true;
            }

            return firstPolynomial.Equals(secondPolynomial);
        }

        /// <summary>
        /// Compares two polynomials.
        /// </summary>
        /// <param name="firstPolynomial">First polynomial.</param>
        /// <param name="secondPolynomial">Second polynomial.</param>
        /// <returns>Boolean result of comparison.</returns>
        public static bool operator !=(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, null) || ReferenceEquals(secondPolynomial, null))
            {
                return false;
            }

            if (ReferenceEquals(firstPolynomial, secondPolynomial))
            {
                return true;
            }

            return !firstPolynomial.Equals(secondPolynomial);
        }
    }
}
