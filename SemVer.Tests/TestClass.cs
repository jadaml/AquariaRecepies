using JAL.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NUnit.Framework.Assert;
using SemVer = JAL.Utilities.SemanticVersion;

namespace JAL.SemanticVersion.Tests
{
    [TestFixture]
    public class TestClass
    {
        private const string Parsing = "Equality and parsing";
        private const string Comparison = "Ordering and Equality";

        private static (string, SemVer)[] versionParsing = new(string, SemVer)[]
        {
            ("1.2.3", new SemVer(1, 2, 3)),
            ("1.2.3-alpha", new SemVer(1, 2, 3, "alpha")),
            ("1.2.3-alpha.1", new SemVer(1, 2, 3, "alpha", 1)),
            ("1.2.3+20130313144700", new SemVer(1, 2, 3, new object[0], new object[] { 20130313144700 })),
            ("1.2.3-alpha.1+20130313144700.11", new SemVer(1, 2, 3, new object[] { "alpha", 1 }, new object[] { 20130313144700, 11 })),
        };

        private static (bool, SemVer, SemVer, OperatorExecution<SemVer>)[] comparisons = new(bool, SemVer, SemVer, OperatorExecution<SemVer>)[]
        {
            (true, new SemVer(1,2,0), new SemVer(2,0,0), new OperatorExecution<SemVer>((a, b) => a < b)),
            (true, new SemVer(1,2,0), new SemVer(2,0,0), new OperatorExecution<SemVer>((a, b) => b > a)),
            (true, new SemVer(1,2,0), new SemVer(2,0,0), new OperatorExecution<SemVer>((a, b) => a <= b)),
            (true, new SemVer(1,2,0), new SemVer(2,0,0), new OperatorExecution<SemVer>((a, b) => b >= a)),
            (true, new SemVer(1,2,0), new SemVer(2,0,0), new OperatorExecution<SemVer>((a, b) => a != b)),
            (false, new SemVer(1,2,0), new SemVer(2,0,0), new OperatorExecution<SemVer>((a, b) => a > b)),
            (false, new SemVer(1,2,0), new SemVer(2,0,0), new OperatorExecution<SemVer>((a, b) => b < a)),
            (false, new SemVer(1,2,0), new SemVer(2,0,0), new OperatorExecution<SemVer>((a, b) => a >= b)),
            (false, new SemVer(1,2,0), new SemVer(2,0,0), new OperatorExecution<SemVer>((a, b) => b <= a)),
            (false, new SemVer(1,2,0), new SemVer(2,0,0), new OperatorExecution<SemVer>((a, b) => a == b)),

            (true, new SemVer(1,0,2), new SemVer(1,1,0), new OperatorExecution<SemVer>((a, b) => a < b)),
            (true, new SemVer(1,0,2), new SemVer(1,1,0), new OperatorExecution<SemVer>((a, b) => b > a)),
            (true, new SemVer(1,0,2), new SemVer(1,1,0), new OperatorExecution<SemVer>((a, b) => a <= b)),
            (true, new SemVer(1,0,2), new SemVer(1,1,0), new OperatorExecution<SemVer>((a, b) => b >= a)),
            (true, new SemVer(1,0,2), new SemVer(1,1,0), new OperatorExecution<SemVer>((a, b) => a != b)),
            (false, new SemVer(1,0,2), new SemVer(1,1,0), new OperatorExecution<SemVer>((a, b) => a > b)),
            (false, new SemVer(1,0,2), new SemVer(1,1,0), new OperatorExecution<SemVer>((a, b) => b < a)),
            (false, new SemVer(1,0,2), new SemVer(1,1,0), new OperatorExecution<SemVer>((a, b) => a >= b)),
            (false, new SemVer(1,0,2), new SemVer(1,1,0), new OperatorExecution<SemVer>((a, b) => b <= a)),
            (false, new SemVer(1,0,2), new SemVer(1,1,0), new OperatorExecution<SemVer>((a, b) => a == b)),

            (true, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0), new OperatorExecution<SemVer>((a, b) => a < b)),
            (true, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0), new OperatorExecution<SemVer>((a, b) => b > a)),
            (true, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0), new OperatorExecution<SemVer>((a, b) => a <= b)),
            (true, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0), new OperatorExecution<SemVer>((a, b) => b >= a)),
            (false, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0), new OperatorExecution<SemVer>((a, b) => a > b)),
            (false, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0), new OperatorExecution<SemVer>((a, b) => b < a)),
            (false, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0), new OperatorExecution<SemVer>((a, b) => a >= b)),
            (false, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0), new OperatorExecution<SemVer>((a, b) => b <= a)),

            (true, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"beta"), new OperatorExecution<SemVer>((a, b) => a < b)),
            (true, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"beta"), new OperatorExecution<SemVer>((a, b) => b > a)),
            (true, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"beta"), new OperatorExecution<SemVer>((a, b) => a <= b)),
            (true, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"bate"), new OperatorExecution<SemVer>((a, b) => b >= a)),
            (false, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"beta"), new OperatorExecution<SemVer>((a, b) => a > b)),
            (false, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"bate"), new OperatorExecution<SemVer>((a, b) => b < a)),
            (false, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"beta"), new OperatorExecution<SemVer>((a, b) => a >= b)),
            (false, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"bate"), new OperatorExecution<SemVer>((a, b) => b <= a)),

            (true, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"alpha","1"), new OperatorExecution<SemVer>((a, b) => a < b)),
            (true, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"alpha","1"), new OperatorExecution<SemVer>((a, b) => b > a)),
            (true, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"alpha","1"), new OperatorExecution<SemVer>((a, b) => a <= b)),
            (true, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"alpha","1"), new OperatorExecution<SemVer>((a, b) => b >= a)),
            (false, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"alpha","1"), new OperatorExecution<SemVer>((a, b) => a > b)),
            (false, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"alpha","1"), new OperatorExecution<SemVer>((a, b) => b < a)),
            (false, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"alpha","1"), new OperatorExecution<SemVer>((a, b) => a >= b)),
            (false, new SemVer(1,0,0,"alpha"), new SemVer(1,0,0,"alpha","1"), new OperatorExecution<SemVer>((a, b) => b <= a)),

            (true, new SemVer(1,2,0), new SemVer(1,2,0), new OperatorExecution<SemVer>((a, b) => a == b)),
            (true, new SemVer(1,2,0,"10"), new SemVer(1,2,0,"10"), new OperatorExecution<SemVer>((a, b) => a == b)),
            (true, new SemVer(1,2,0,"alpha"), new SemVer(1,2,0,"alpha"), new OperatorExecution<SemVer>((a, b) => a == b)),
            (true, new SemVer(1,2,0,"alpha"), new SemVer(1,2,0, new object[] { "alpha" }, new object[] { "ignored" }), new OperatorExecution<SemVer>((a, b) => a == b)),
        };

        [TestCaseSource(nameof(versionParsing), Category = Parsing)]
        public void FromString((string, SemVer) input)
        {
            AreEqual(input.Item2, SemVer.Parse(input.Item1));
        }

        [TestCaseSource(nameof(versionParsing), Category = Parsing)]
        public void AsString((string, SemVer) input)
        {
            AreEqual(input.Item1, input.Item2.ToString());
        }

        [Test]
        [Category(Parsing)]
        public void ParsingError()
        {
            Throws<ArgumentException>(() => new SemVer("?! $+-"));
            Throws<ArgumentException>(() => new SemVer("138"));
            Throws<ArgumentException>(() => new SemVer("1.0"));
            Throws<ArgumentException>(() => new SemVer("1.0.02"));
        }

        [TestCaseSource(nameof(comparisons), Category = Comparison)]
        public void Comparisons((bool, SemVer, SemVer, OperatorExecution<SemVer>) input)
        {
            if (input.Item1)
            {
                IsTrue(input.Item4.Invoke(input.Item2, input.Item3));
            }
            else
            {
                IsFalse(input.Item4.Invoke(input.Item2, input.Item3));
            }
        }
    }
}
